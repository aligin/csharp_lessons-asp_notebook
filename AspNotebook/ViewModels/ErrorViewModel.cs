using System;

namespace AspNotebook.ViewModels
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId
        {
            get
            {
                //bool result;
                //if (!string.IsNullOrEmpty(RequestId))
                //    result = true;
                //else
                //    result = false;
                //return result;
                return !string.IsNullOrEmpty(RequestId);
            }
        }
    }
}
