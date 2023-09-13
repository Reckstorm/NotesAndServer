using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesClasses
{
    public class Note
    {
        public int id { get; set; }
        public string name { get; set; }
        public string text { get; set; }
        public DateTime modified { get; set; }
        public Note()
        {
            id = 0;
            name = string.Empty;
            text = string.Empty;
            modified = DateTime.MinValue;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode() + name.GetHashCode() + text.GetHashCode() + modified.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            obj = obj as Note;
            if (obj == null) return false;
            if (obj.GetType() != typeof(Note)) return false;
            return this.GetHashCode().Equals(obj.GetHashCode());
        }
    }
}
