using System;

namespace csharp_exercises_201907_CheeseMVC_Class12_EntityFramework.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
