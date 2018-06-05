using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Translation
    {
        public int TranslationId { get; set; }

        [MaxLength(4096)]
        public string Value { get; set; }

        [MaxLength(12)]
        public string Culture { get; set; }

        public int MultiLangStringId { get; set; }
        public virtual MultiLangString MultiLangString { get; set; }

    }
}
