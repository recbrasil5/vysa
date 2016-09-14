﻿using System;
using System.Collections.Generic;
using System.Web.Http;
using VYSA.Domain.Concrete;
using VYSA.WebApi.Models.Resource;
using VYSA.WebApi.Services;

namespace VYSA.WebApi.Controllers
{
    [RoutePrefix("Announcements")]
    public class AnnouncementsController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private AnnouncementService announcementsService;

        public AnnouncementsController()
        {
            announcementsService = new AnnouncementService(unitOfWork);
        }

        [HttpGet] // /api/Announcement
        [Route("")]
        public IEnumerable<AnnouncementResourceModel> GetAnnouncements() //webApi call
        {
            return announcementsService.GetAnnouncementResourceModels(false);
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
        
        #region old constructor code
        //once needed paramaterless constructor in order for webApi calls to be made (see Infrstructure/Ninject to get rid of need)
        //public AnnouncementsController()
        //{
        //    unitOfWork = new UnitOfWork();
        //    _announcementsVmBuilder = new AnnouncementsVmBuilder(unitOfWork);
        //}
        #endregion
    }    
}