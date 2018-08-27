using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dataTable.Models;
using LinqToExcel;
using System.Data.Entity;
using System.IO;
using System.Web.UI.WebControls;

namespace dataTable.Controllers
{
    public class HomeController : Controller
    {
        Models.CBOPortalEntities DbContext = new Models.CBOPortalEntities();
        public const string NewWinsDetails = "NewWinsDetails";
        public const string PipelineDetails = "PipelineDetails";
        public const string CBOUpdatesDetails = "CBOUpdatesDetails";
        public const string AlertDetails = "AlertDetails";
        public const string SpotLightDetails = "SpotLightDetails";
        public const string EventDetails = "EventDetails";

        public ActionResult Index()
        {
            var model = new List<MaintenanceViewModel>();
            foreach (var item in DbContext.NewWinsDetails)
            {
                var data = new MaintenanceViewModel();
                data.ProjectName = item.ProjectName;
                data.ProjectDescription = item.ProjectDescription;
                data.ContactName = item.ContactName;
                data.ContactEmail = item.ContactEmail;
                data.StartDate = item.StartDate;
                data.ID = item.ID;
                model.Add(data);
            }
            return View(model);
        }

        [HttpPost]
        public int InsertNewWinDetails(string projectName, string projectDescription, string contactName, string contactEmail, DateTime startDate)
        {
            Models.CBOPortalEntities DbContext = new Models.CBOPortalEntities();

            DbContext.NewWinsDetails.Add(new Models.NewWinsDetails
            {
                ProjectName = projectName,
                ProjectDescription = projectDescription,
                ContactName = contactName,
                ContactEmail = contactEmail,
                CategoryCode = "CC",
                StartDate = startDate,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                CreatedBy = "admin",
                UpdatedBy = "admin"
            });
            DbContext.SaveChanges();
            int id = DbContext.NewWinsDetails.FirstOrDefault(x => x.ProjectName == projectName).ID;
            return id;
        }

        [HttpPost]
        public void UpdateAddWinDetails(MaintenanceViewModel model)
        {
            Models.CBOPortalEntities DbContext = new Models.CBOPortalEntities();
            var obj = DbContext.NewWinsDetails.FirstOrDefault(x => x.ID == model.ID);
            obj.ProjectName = model.ProjectName;
            obj.ProjectDescription = model.ProjectDescription;
            obj.ContactName = model.ContactName;
            obj.ContactEmail = model.ContactEmail;
            obj.StartDate = model.StartDate;
            DbContext.SaveChanges();
        }

        [HttpPost]
        public int DeleteAddWinDetails(int ID)
        {
            Models.CBOPortalEntities DbContext = new Models.CBOPortalEntities();
            DbContext.NewWinsDetails.Remove(DbContext.NewWinsDetails.FirstOrDefault(x => x.ID == ID));
            DbContext.SaveChanges();
            return 0;
        }

        [HttpPost]
        public ActionResult UploadExcel(HttpPostedFileBase FileUpload)
        {
            Models.CBOPortalEntities DbContext = new Models.CBOPortalEntities();
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            string data = "";
            ExcelQueryFactory excelFile = new ExcelQueryFactory();
            try
            {
                if (FileUpload != null)
                {
                    if (FileUpload.ContentType == "application/vnd.ms-excel" || FileUpload.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        string filename = FileUpload.FileName;

                        if (filename.EndsWith(".xlsx"))
                        {
                            string targetpath = Server.MapPath("~/UploadedExcels/");
                            string pathToExcelFile = targetpath + filename;
                            //if (System.IO.File.Exists(pathToExcelFile))
                            //{
                            //    pathToExcelFile = targetpath + pathToExcelFile.Split('\\').Last().Split('.')[0] + "_1" + ".xlsx";
                            //}
                            FileUpload.SaveAs(pathToExcelFile);
                            Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Open(pathToExcelFile, Notify: false, ReadOnly: true);
                            int workSheetCounts = wb.Worksheets.Count;
                            for (int sheetCounter = 1; sheetCounter <= workSheetCounts; sheetCounter++)
                            {
                                Microsoft.Office.Interop.Excel.Worksheet workSheet = wb.Sheets[sheetCounter];

                                string sheetName = workSheet.Name;

                                excelFile = new ExcelQueryFactory(pathToExcelFile);
                                var empDetails = from a in excelFile.Worksheet<MaintenanceViewModel>(sheetName) select a;
                                foreach (var model in empDetails)
                                {
                                    if (model.CategoryCode != null)
                                    {
                                        //if (a.MobileNo.Length > 12)
                                        //{
                                        //    data = "Phone number should be 10 to 12 disit";
                                        //    ViewBag.Message = data;

                                        //}
                                        int result = 0;
                                        switch (sheetName)
                                        {
                                            case NewWinsDetails:
                                                result = PostNewWinsDetailsExcelData(model);
                                                break;
                                            case PipelineDetails:
                                                result = PostPipelineDetailsExcelData(model);
                                                break;
                                            case CBOUpdatesDetails:
                                                result = PostCBOUpdatesDetailsExcelData(model);
                                                break;
                                            case AlertDetails:
                                                result = PostAlertDetailsExcelData(model);
                                                break;
                                            case SpotLightDetails:
                                                result = PostSpotLightDetailsExcelData(model);
                                                break;
                                            case EventDetails:
                                                result = PostEventDetailsExcelData(model);
                                                break;
                                            default:
                                                break;
                                        }
                                        //resullt = PostExcelData(a.Project_Name, a.ProjectDescription, a.ContactName, a.ContactEmail, a.StartDate, a.CategoryCode, a.IsMobileSupported == "Y");
                                        if (result == 0)
                                        {
                                            data = "Hello User, Found some duplicate values! Only unique employee number has inserted and duplicate values(s) are not inserted";
                                            ViewBag.Message = data;
                                            continue;
                                        }
                                        else
                                        {
                                            data = "Successful upload records";
                                            ViewBag.Message = data;
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                          
                        }
                        else
                        {
                            data = "This file is not valid format";
                            ViewBag.Message = data;
                        }
                    }
                    else
                    {
                        data = "Only Excel file format is allowed";
                        ViewBag.Message = data;
                    }
                }
                else
                {
                    if (FileUpload == null)
                    {
                        data = "Please choose Excel file";
                    }
                    ViewBag.Message = data;
                }
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message.ToString();
            }

            finally
            {
                excelFile.Dispose();
                app.Workbooks.Close();
            }
            return RedirectToAction("Index");
        }

        public int PostNewWinsDetailsExcelData(MaintenanceViewModel model)
        {
            try
            {
                DbContext.NewWinsDetails.Add(new Models.NewWinsDetails
                {
                    ProjectName = model.ProjectName,
                    ProjectDescription = model.ProjectDescription,
                    ContactName = model.ContactName,
                    ContactEmail = model.ContactEmail,
                    CategoryCode = model.CategoryCode,
                    StartDate = Convert.ToDateTime(model.StartDate),
                    IsMobileDisplay = model.IsMobileDisplaySupported == "Y",
                    CreatedDate = DateTime.Now,
                    IsActive = model.IsActive == "Y",
                    UpdatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin"
                });
                DbContext.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {

                return 0;
            }
        }

        public int PostPipelineDetailsExcelData(MaintenanceViewModel model)
        {
            try
            {
                DbContext.PipelineDetails.Add(new Models.PipelineDetails
                {
                    ProjectName = model.ProjectName,
                    ProjectDescription = model.ProjectDescription,
                    CategoryCode = model.CategoryCode,
                    ExpectedStartDate = Convert.ToDateTime(model.ExpectedStartDateOfProject),
                    IsMobileDisplay = model.IsMobileDisplaySupported == "Y",
                    ContactName = model.ContactPerson,
                    ContactEmail = model.ContactMailId,
                    IsActive = model.IsActive == "Y",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin"
                });
                DbContext.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {

                return 0;
            }
        }

        public int PostCBOUpdatesDetailsExcelData(MaintenanceViewModel model)
        {
            try
            {
                DbContext.CBOUpdatesDetails.Add(new Models.CBOUpdatesDetails
                {
                    CategoryCode = model.CategoryCode,
                    Description = model.Description,
                    Document = model.Document,
                    IsMobileDisplay = model.IsMobileDisplaySupported == "Y",
                    IsActive = model.IsActive == "Y",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin"
                });
                DbContext.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {

                return 0;
            }
        }

        public int PostAlertDetailsExcelData(MaintenanceViewModel model)
        {
            try
            {
                DbContext.AlertDetails.Add(new Models.AlertDetails
                {
                    CategoryCode = model.CategoryCode,
                    Description = model.Description,
                    Document = model.Document,
                    IsMobileDisplay = model.IsMobileDisplaySupported == "Y",
                    IsActive = model.IsActive == "Y",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin"
                });
                DbContext.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {

                return 0;
            }
        }

        public int PostSpotLightDetailsExcelData(MaintenanceViewModel model)
        {
            try
            {
                DbContext.SpotLightDetails.Add(new Models.SpotLightDetails
                {
                    CategoryCode = model.CategoryCode,
                    EmployeeName = model.EmployeeName,
                    Description = model.Description,
                    EmployeeEmailId = model.EmployeeEmailId,
                    Month = model.Month,
                    ProjectName = model.ProjectName,
                    IsMobileDisplay = model.IsMobileDisplaySupported == "Y",
                    IsActive = model.IsActive == "Y",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin"
                });
                DbContext.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {

                return 0;
            }
        }



        public int PostEventDetailsExcelData(MaintenanceViewModel model)
        {
            try
            {
                DbContext.EventDetails.Add(new Models.EventDetails
                {   
                    CategoryCode = model.CategoryCode,
                    Description = model.Description,
                    Frequency = model.Frequency,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    IsMobileDisplay = model.IsMobileDisplaySupported == "Y",
                    Document = model.Document,
                    IsActive = model.IsActive == "Y",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedBy = "admin"
                });
                DbContext.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {

                return 0;
            }
        }







    }
}