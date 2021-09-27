using System.Collections.Generic;

namespace Infrastructure.Abstractions.Model
{
    public class EmailSendResult
    {
        public bool IsSuccessful { get; set; }
        public IEnumerable<string> ErrorMessages { get; set; }
    }
}
