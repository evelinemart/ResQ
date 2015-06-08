using Novacode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ResQ.Models;
using System.Drawing;

namespace ResQ.Infrastructure
{
    public static class FileCreator
    {
        public static void CreateReport(Request info, DocX document)
        {
            Paragraph text2 = document.InsertParagraph();
            string append;
            append = "ID запросса: " + info.ID + ".\n" +
                    "Потерпевший(-ая): " + info.User.UserLastName + " " + info.User.UserFirstName +
                    "\nДата принятия запросса: " + info.Date + ".\nДата обработки: " + info.DateFinished + ".\n" +
                    "Пожарная часть, которая выехала на вызов: " + info.FireStation.FireStationName + ".\n" +
                    "Tочка сигнала SOS - X:" + info.Location.X + ", Y:" + info.Location.Y + ".";
            text2.Append(append).Font(new FontFamily("Times New Roman")).FontSize(14);
            text2.IndentationFirstLine = 1.0f;
            document.Save();
        }
    }
}