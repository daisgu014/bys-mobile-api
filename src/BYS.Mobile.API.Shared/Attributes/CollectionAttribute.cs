using System;

namespace BYS.Mobile.API.Shared.Attributes
{
    public class CollectionAttribute : Attribute
    {
        public CollectionAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
