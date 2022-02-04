using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACE
{
    public partial class Client
    {
        /// <summary>
        /// Путь к изображению с учетом заглушки
        /// </summary>
        public string PicturePath => PhotoPath ?? "../../Resources/beauty_logo.png";
    }
}
