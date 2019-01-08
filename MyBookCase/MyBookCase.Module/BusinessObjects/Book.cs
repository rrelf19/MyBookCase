using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace MyBookCase.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Book : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Book(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { SetPropertyValue("Title", ref title, value); }
        }

        private string isbn;
        public string ISBN
        {
            get { return isbn; }
            set { SetPropertyValue("Isbn", ref isbn, value); }
        }



        private MediaDataObject cover;
        public MediaDataObject Cover
        {
            get { return cover; }
            set { SetPropertyValue("Cover", ref cover, value); }
        }
    }

    [DefaultClassOptions]
    public class Author : BaseObject
    {
        public Author(Session session) : base(session) { }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { SetPropertyValue("FirstName", ref firstName, value); }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { SetPropertyValue("LastName", ref lastName, value); }
        }

        [NonPersistent]
        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", FirstName ?? "", LastName ?? "");
            }
        }
    }
}