using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ColorPick.Picker;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongThiNghhiem.Resources
{
     public static class Funtion
     {
          public static DataTable ToDataTable<T>(this IEnumerable<T> items)
          {
               // Create the result table, and gather all properties of a T        
               DataTable table = new DataTable(typeof(T).Name);
               PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

               // Add the properties as columns to the datatable
               foreach (var prop in props)
               {
                    Type propType = prop.PropertyType;

                    // Is it a nullable type? Get the underlying type 
                    if (propType.IsGenericType && propType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                         propType = new NullableConverter(propType).UnderlyingType;

                    table.Columns.Add(prop.Name, propType);
               }

               // Add the property values per T as rows to the datatable
               foreach (var item in items)
               {
                    var values = new object[props.Length];
                    for (var i = 0; i < props.Length; i++)
                         values[i] = props[i].GetValue(item, null);

                    table.Rows.Add(values);
               }

               return table;
          }

          public static byte[] convertImageToBytes(string ImagePath)
          {
               FileStream fs = new FileStream(ImagePath, FileMode.Open, FileAccess.Read);
               byte[] picBytes = new byte[fs.Length];
               fs.Read(picBytes, 0, System.Convert.ToInt32(fs.Length));
               fs.Close();
               return picBytes;
          }

          public static byte[] convertImageToBytes(Image HinhAnh)
          {
               if (HinhAnh == null)
               {
                    Byte[] imgtype = { 0 };
                    return imgtype;
               }
               MemoryStream ms = new MemoryStream();
               HinhAnh.Save(ms, HinhAnh.RawFormat);
               return ms.ToArray();
          }

          public static Image convertBytesToImage(byte[] bytesImage)
          {
               try
               {
                    MemoryStream ms = new MemoryStream(bytesImage);
                    return Image.FromStream(ms);
               }
               catch
               {
                    return null;
               }
          }

          public static void chon(Label lb, Panel pn)
          {
               pn.Height = 2;
               lb.Font = new Font(new FontFamily("Times New Roman"), (float)13, FontStyle.Bold);
          }

          public static void khongChon(Label lb, Panel pn)
          {
               pn.Height = 1;
               lb.Font = new Font(new FontFamily("Times New Roman"), (float)12.75, FontStyle.Regular);
          }
          public static void chon(Label lb)
          {
               lb.Font = new Font(new FontFamily("Microsoft Sans Serif"), (float)12.25);
               lb.ForeColor = Color.FromArgb(30, 200, 250);
          }
          public static void khongChon(Label lb)
          {
               lb.Font = new Font(new FontFamily("Microsoft Sans Serif"), (float)12);
               lb.ForeColor = Color.FromArgb(175, 205, 242);
          }

          public static void chon( PanelControl pn)
          {
               pn.BorderStyle = BorderStyles.HotFlat;
          }

          public static void khongChon(PanelControl pn)
          {
               pn.BorderStyle = BorderStyles.Simple;
          }

          public static void btChon(Button bt)
          {
               bt.BackColor = Color.FromArgb(78, 182, 236);
               bt.ForeColor = Color.White;
          }

          public static void btKhongChon(Button bt)
          {
               bt.BackColor = Color.White;
               bt.ForeColor = Color.FromArgb(78, 182, 236);
          }
     }
}
