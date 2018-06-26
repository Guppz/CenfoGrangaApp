using POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Message : BaseEntity
    {
        public int id { get; set; }
        public string descripsion { get; set; }
    }
}
