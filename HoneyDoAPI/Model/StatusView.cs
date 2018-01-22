using HoneyDoAPI.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace HoneyDoAPI.Model
{
    public class StatusView : ValueObject<StatusView>
    {
        public virtual string Type { get; protected set; }

        public StatusView(string type)
        {
            Contract.Ensures(type != null);
            this.Type = type;
        }

        public static List<StatusView> GetStatusList()
        {
            List<string> typeValues = new List<string>() { "OPEN", "COMPLETE", "CANCELED", "FUTURE" };
            List<StatusView> statusList = new List<StatusView>();
            typeValues.ForEach(x => statusList.Add(new StatusView(x)));
            return statusList;
        }

        protected override bool EqualsCore(StatusView other)
        {
            return this.Type == other.Type;
        }

        protected override int GetHashCodeCore()
        {
            return this.Type.GetHashCode();
        }
    }
}
