﻿namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter05.Listing05_47
{
    using System;
    // File: Person.Designer.cs
    public partial class Person
    {
        #region Extensibility Method Definitions
        partial void OnLastNameChanging(string value);
        partial void OnFirstNameChanging(string value);
        #endregion

        // ...
        public System.Guid PersonId{ get; set;}
        private System.Guid _PersonId;

        // ...
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                if ((_LastName != value))
                {
                    OnLastNameChanging(value);
                    _LastName = value;
                }
            }
        }
        private string _LastName;

        // ...
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                if ((_FirstName != value))
                {
                    OnFirstNameChanging(value);
                    _FirstName = value;
                }
            }
        }
        private string _FirstName;

    }
    // File: Person.cs
    partial class Person
    {
        partial void OnLastNameChanging(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("LastName");
            }
            if (value.Trim().Length == 0)
            {
                throw new ArgumentException(
                    "LastName cannot be empty.");
            }
        }
    }

}
