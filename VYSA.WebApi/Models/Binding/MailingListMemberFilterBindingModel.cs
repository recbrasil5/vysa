﻿using System;

namespace VYSA.WebApi.Models.Binding
{
    public class MailingListMemberFilterBindingModel : FilterBindingModel
    {
        public Boolean MailingList { get; set; }
        public Boolean Guardians { get; set; }
        public Boolean Coaches { get; set; }
        public Boolean ParentReps { get; set; }
        public Boolean BoardMembers { get; set; }

        public Boolean IsConfigDefined
        {
            get { return MailingList || Guardians || Coaches || ParentReps || BoardMembers; }
        }
    }
}