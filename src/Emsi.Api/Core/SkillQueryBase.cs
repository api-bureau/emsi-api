using System.Collections.Generic;

namespace Emsi.Api.Core
{
    public class SkillQueryBase
    {
        /// <summary>
        /// Default "id,name,type,infoUrl"
        /// </summary>
        public string Fields { get; set; } = "id,name,type,infoUrl";

        public List<string> TypeIds { get; set; } = new List<string>();


        //ToDo Implement query buider
        public virtual string Create()
        {
            return string.Empty;
        }
    }
}
