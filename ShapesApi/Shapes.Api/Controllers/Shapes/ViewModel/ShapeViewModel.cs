using Shapes.Domain.Model;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes.Api.Controllers.Shapes
{
    public class ShapeViewModel 
    {
        public string Id { get; set; }
    }

    [Obsolete("Use individual action method for each shape")]
    public class ShapeViewModel_OLD
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public dynamic Data { get; set; } = new ExpandoObject();
    }

    //public class ShapeViewModel : DynamicObject
    //{
    //    public string Id { get; set; }
    //    public string Type { get; set; }
    //    //public dynamic Data { get; set; } = new ExpandoObject();


    //    Dictionary<string, object> dictionary = new Dictionary<string, object>();
    //    public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
    //    {
    //        string name = binder.Name.ToLower();
    //        return dictionary.TryGetValue(name, out result);
    //    }

    //    public override bool TrySetMember(SetMemberBinder binder, object value)
    //    {
    //        dictionary[binder.Name.ToLower()] = value;
    //        return true;
    //    }
    //}
}
