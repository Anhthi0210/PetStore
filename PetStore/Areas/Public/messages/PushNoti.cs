using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetStore
{
    public class PushNoti//can use anywhere
    {
        public string TypeNoti { get; set; }
        public string Content { get; set; }
        public PushNoti() { }
        public PushNoti(string typeNoti, string content)
        {
            this.TypeNoti= typeNoti;
            this.Content = content;
        }
    }
}