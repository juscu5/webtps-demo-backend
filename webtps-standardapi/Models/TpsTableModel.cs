using System;

namespace webtps_standardapi.Models
{
    public class TpsModel
    {
        public Guid TPS_ID { get; set; }
        public string? TPS_NAME { get; set; }
        public float TPS_MODE { get; set; }
        public float STATUS { get; set; }

    }

    public class TypeModel
    {
        public Guid TYPE_ID { get; set; }
        public Guid TPS_ID { get; set; }
        public string? TYPE_NAME { get; set; }
        public float STATUS { get; set; }
    }

    public class SubtypeModel
    {
        public Guid SUBT_ID { get; set; }
        public Guid TYPE_ID { get; set; }
        public string? SUBT_NAME { get; set; }
        public float STATUS { get; set; }
    }

    public class DataModel
    {
        public Guid DATA_ID { get; set; }
        public Guid SUBT_ID { get; set; }
        public string? DATA_VAL { get; set; }
        public DateTime DATE_MD { get; set; }
        public float STATUS { get; set; }
    }
}
