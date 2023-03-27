using DataAccessLayer.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.ViewModels.ViewModels
{
    public class DocumentationVM
    {
        public int DocumentationId { get; set; }
        public string Name { get; set; }
        public string DescriptionA { get; set; }
        public string DescriptionB { get; set; } //En la descripcion me tienes que decir que es lo que quieres de tamaño 
        public string Link { get; set; }
        public string Price { get; set; } //Esto no me acuerdo para que era
        public DateTime RegisterDate { get; set; }
        public int UserId { get; set; }
        public UserVM User { get; set; }
        public bool DocumentationCheck { get; set; }


        public string LinkB { get; set; }

        public DocumentationVM(Documentation d)
        {
            DocumentationId = d.DocumentationId;
            Name = d.Name;
            DescriptionA = d.DescriptionA;
            DescriptionB = d.DescriptionB;
            Link = d.Link;
            RegisterDate = d.RegisterDate;
            UserId = d.UserId;
            if(d.User != null)
            {
                User = new UserVM(d.User);
            }
            DocumentationCheck = d.DocumentationCheck;
            LinkB = d.LinkB;
        }

        public DocumentationVM() { }
    }
}
