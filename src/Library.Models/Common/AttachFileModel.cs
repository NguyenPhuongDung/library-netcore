using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models.Common
{
    public class AttachFileModel
    {
        public string Folder { get; set; }
        public string FileName { get; set; }
        public string FileId { get; set; }
        public string Extension { get; set; }
        public string Base64 { get; set; }
        public string ContentType { get; set; }
    }
}
