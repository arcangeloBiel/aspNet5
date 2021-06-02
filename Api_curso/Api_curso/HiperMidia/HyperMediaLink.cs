using System.Text;

namespace Api_curso.HiperMidia {
    public class HyperMediaLink {
        public string Rel { get; set; }

        private string href;
        public string Action { get; set; }
        public string Type { get; set; }

        public string Href {
            get {
                object _lock = new object();
                lock (_lock) {
                    StringBuilder sb = new StringBuilder(Href);
                    return sb.Replace("%2F", "/").ToString();

                }

            }

            set {
                href = value;
            }
        }
    }
}
