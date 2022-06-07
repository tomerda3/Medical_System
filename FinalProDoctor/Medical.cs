using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace FinalProDoctor
{
    public partial class Medical : Form
    {
        public static Medical instance;

        public Medical()
        {
            InitializeComponent();
            instance = this;
        }
        Patient patient1 = null;
        private void button7_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Medical_Load(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            float WBC=0;
            float Neut = 0;
            float Lymph = 0;
            float RBC = 0;
            float HCT = 0;
            float Urea = 0;
            float Hb = 0;
            float Crtn = 0;
            float Iron = 0;
            float HDL = 0;
            float AP = 0;
            
            textBox5.Text = "";
            chart1.Titles.Clear();
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }

            string sex = "male";
            if (checkBox1.Checked)
                sex = "male";
            else sex = "female";

            bool pregnant=false;
            if (checkBox6.Checked)
                pregnant = true;
            if (sex == "male")
                pregnant = false;
            bool drugs = false;
            if (checkBox8.Checked)
                drugs = true;

            int age = 0;

            try
            {
                age = Int32.Parse(textBox2.Text);
            }

            catch (FormatException e1)
            {
                textBox5.Text = "No input data";
                return;
            }



            if (age > 120 || age < 0)
            {
                textBox5.Text = "The age is off limit";
                return;
            }
            string idd = textBox7.Text;
            if (idd.Length != 8)
            {
                textBox5.Text = "The id is too short or too big";
                return;
            }
            float weight =float.Parse(textBox4.Text);
            if (weight > 500 || weight < 0)
            {
                textBox5.Text = "The weight is too short or too big";
                return;
            }
            float high = float.Parse(textBox3.Text);
            if (high > 300 || high < 0)
            {
                textBox5.Text = "The high is too short or too big";
                return;
            }

            try
            {
                int orindex = comboBox1.SelectedIndex;
                patient1 = new Patient(textBox1.Text, textBox6.Text, age, sex, checkBox4.Checked, high, weight, orindex, pregnant,drugs, idd);
            }

            catch (FormatException e1)
            {
                textBox5.Text = "There is a problem in the input data";
                return;
            }

            textBox5.Text = "";
        }

        private void WBCBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            textBox5.Text = "";

            if (patient1 == null)
            {
                MessageBox.Show("You need to add patient first");
                return;
            }

            if (patient1.WBC == 0 || patient1.Neut == 0 || patient1.Lymph == 0 || patient1.RBC == 0 || patient1.HCT == 0 || patient1.Urea == 0 || patient1.Hb == 0 || patient1.Crtn == 0 || patient1.Iron == 0 || patient1.HDL == 0 || patient1.AP == 0)
            {
                MessageBox.Show("You need to add Blood Test ");
                return;
            }
            
            chart1.Series["BloodTest"].Points.AddXY("WBC", patient1.WBC);
            chart1.Series["BloodTest"].Points.AddXY("Neut", patient1.Neut);
            chart1.Series["BloodTest"].Points.AddXY("Lymph", patient1.Lymph);
            chart1.Series["BloodTest"].Points.AddXY("RBC", patient1.RBC);
            chart1.Series["BloodTest"].Points.AddXY("HCT", patient1.HCT);
            chart1.Series["BloodTest"].Points.AddXY("Urea", patient1.Urea);
            chart1.Series["BloodTest"].Points.AddXY("Hb", patient1.Hb);
            chart1.Series["BloodTest"].Points.AddXY("Crtn", patient1.Crtn);
            chart1.Series["BloodTest"].Points.AddXY("Iron", patient1.Iron);
            chart1.Series["BloodTest"].Points.AddXY("HDL", patient1.HDL);
            chart1.Series["BloodTest"].Points.AddXY("AP", patient1.AP);
            chart1.Titles.Add("BloodTest Result");

            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
            richTextBox2.SelectionAlignment = HorizontalAlignment.Right;
            richTextBox1.AppendText(" : שם המטופל " + patient1.firstName);
            richTextBox1.AppendText("\n : אבחון המטופל\n");

            if (patient1.age >= 18)
                analysisForAdult();
            if (patient1.age < 18 && patient1.age > 3)
                analysisForChildren();
            if (patient1.age <= 3)
                analysisForbaby();

            Microsoft.Office.Interop.Excel.Application myexcelApplication = new Microsoft.Office.Interop.Excel.Application();
            if (myexcelApplication != null)
            {
                Microsoft.Office.Interop.Excel.Workbook myexcelWorkbook = myexcelApplication.Workbooks.Add();
                Microsoft.Office.Interop.Excel.Worksheet myexcelWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)myexcelWorkbook.Sheets.Add();

                myexcelWorksheet.Cells[1, 1] = "First Name";
                myexcelWorksheet.Cells[1, 2] = "Last Name";
                myexcelWorksheet.Cells[1, 3] = "ID";
                myexcelWorksheet.Cells[1, 4] = "Age";
                myexcelWorksheet.Cells[1, 5] = "Gender";
                myexcelWorksheet.Cells[1, 6] = "Smoking";
                myexcelWorksheet.Cells[1, 7] = "Pragnent";
                myexcelWorksheet.Cells[1, 8] = "Taken Drugs";
                myexcelWorksheet.Cells[1, 9] = "Height";
                myexcelWorksheet.Cells[1, 10] = "Weight";
                myexcelWorksheet.Cells[1, 11] = "Ethnic group";
                myexcelWorksheet.Cells[1, 12] = "WBC";
                myexcelWorksheet.Cells[1, 13] = "Neut";
                myexcelWorksheet.Cells[1, 14] = "Lymph";
                myexcelWorksheet.Cells[1, 15] = "RBC";
                myexcelWorksheet.Cells[1, 16] = "HCT";
                myexcelWorksheet.Cells[1, 17] = "Urea";
                myexcelWorksheet.Cells[1, 18] = "Hb";
                myexcelWorksheet.Cells[1, 19] = "Crtn";
                myexcelWorksheet.Cells[1, 20] = "Iron";
                myexcelWorksheet.Cells[1, 21] = "HDL";
                myexcelWorksheet.Cells[1, 22] = "AP";
                myexcelWorksheet.Cells[1, 23] = "Diagnosis";
                myexcelWorksheet.Cells[1, 24] = "Recommendation";

                myexcelWorksheet.Cells[2, 1] = patient1.firstName;
                myexcelWorksheet.Cells[2, 2] = patient1.lastName;
                myexcelWorksheet.Cells[2, 3] = patient1.id.ToString();
                myexcelWorksheet.Cells[2, 4] = patient1.age.ToString();
                myexcelWorksheet.Cells[2, 5] = patient1.sex;
                if(patient1.smoke == true)
                    myexcelWorksheet.Cells[2, 6] = "Yes";
                else myexcelWorksheet.Cells[2, 6] = "No";

                if (patient1.pregpregnant == true)
                    myexcelWorksheet.Cells[2, 7] = "Yes";
                else myexcelWorksheet.Cells[2, 7] = "No";

                if (patient1.takedrugs == true)
                    myexcelWorksheet.Cells[2, 8] = "Yes";
                else myexcelWorksheet.Cells[2, 8] = "No";
                
                myexcelWorksheet.Cells[2, 9] = patient1.weight;
                myexcelWorksheet.Cells[2, 10] = patient1.high;
                string origin = "";
                if (patient1.origin == 0)
                    origin = "Ethipoian";
                if (patient1.origin == 1)
                    origin = "Ashknazi";
                else origin = "mizrahi";
                myexcelWorksheet.Cells[2, 11] = origin;
                myexcelWorksheet.Cells[2, 12] = patient1.WBC.ToString();
                myexcelWorksheet.Cells[2, 13] = patient1.Neut.ToString() + "%";
                myexcelWorksheet.Cells[2, 14] = patient1.Lymph.ToString() + "%";
                myexcelWorksheet.Cells[2, 15] = patient1.RBC.ToString();
                myexcelWorksheet.Cells[2, 16] = patient1.HCT.ToString() + "%";
                myexcelWorksheet.Cells[2, 17] = patient1.Urea.ToString();
                myexcelWorksheet.Cells[2, 18] = patient1.Hb.ToString();
                myexcelWorksheet.Cells[2, 19] = patient1.Crtn.ToString();
                myexcelWorksheet.Cells[2, 20] = patient1.Iron.ToString();
                myexcelWorksheet.Cells[2, 21] = patient1.HDL.ToString();
                myexcelWorksheet.Cells[2, 22] = patient1.AP.ToString();

                myexcelWorksheet.Cells[2, 23] = patient1.di; //DIAG
                myexcelWorksheet.Cells[2, 24] = patient1.se;//REC

                try
                {                
                    myexcelApplication.ActiveWorkbook.SaveAs(@"C: \Users\Tomer\OneDrive\Desktop\info.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                }

                catch (COMException e1)
                {
                }

                myexcelWorkbook.Close();
                myexcelApplication.Quit();
            }

        }
        public void setBlood(float WBC, float Neut, float Lymph, float RBC, float HCT, float Urea, float Hb, float Crtn, float Iron, float HDL, float AP)
        {
            patient1.setBloodTest(WBC, Neut, Lymph, RBC, HCT, Urea, Hb, Crtn, Iron, HDL, AP);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (patient1 == null)
            {
                MessageBox.Show("You need to add patient first");
                return;
            }
            BloodTest start = new BloodTest();
            // this.Hide();
            start.Show();
            ///  this.Close();
        }
        public void analysisForAdult()
        {
            int count = 1;
            int count2 = 1;
            if (11000 < patient1.WBC)
            {
                richTextBox1.AppendText(count + ".ערך גבוה של כדורי דם לבנים יכולות להצביע על קיומו של זיהום, אם קיימת מחלת חום. במקרים אחרים, נדירים ביותר, עלולים ערכים גבוהים מאוד להעיד על מחלת דם או סרטן\n");
                count++;
                richTextBox2.AppendText("שילוב של ציקלופוספאמיד וקורטיקוסרואידים\n" + count2);
                count2++;
                richTextBox2.AppendText("אנטרקטיניב - Entrectinib\n" + count2);
                count2++;
                richTextBox2.AppendText("אנטיביוטיקה ייעודית\n" + count2);
                count2++;

            }
            if (4500 > patient1.WBC)
            {
                richTextBox1.AppendText(count + ". קיים ערך נמוך של כדורי דם לבנים היכול להצביע על מחלה ויראלית, כשל של מערכת החיסון ובמקרים נדירים ביותר על סרטן\n");
                count++;
                richTextBox2.AppendText("לנוח בבית\n" + count2);
                count2++;
                richTextBox2.AppendText("אנטרקטיניב - Entrectinib\n" + count2);
                count2++;
            }

            if (54 < patient1.Neut)
            {
                richTextBox1.AppendText(count + ".ערך גבוה של נויטרופיל מעידים לרוב על זיהום חיידקי.\n");
                count++;
                richTextBox2.AppendText("אנטיביוטיקה ייעודית\n" + count2);
                count2++;
            }

            if (28 < patient1.Neut)
            {
                richTextBox1.AppendText(count + ".ערך נמוך של נויטרופיל מעידים על הפרעה ביצירת הדם, על נטייה לזיהומים מחיידקים ובמקרים נדירים - על תהליך סרטני.\n");
                count++;
                richTextBox2.AppendText("כדור 10 מג של בי-12 ביום למשך חודש, כדור 5 מג של חומצה פולית ביום למשך חודש \n" + count2);
                count2++;
                richTextBox2.AppendText("כדור 10 מג של בי-12 ביום למשך חודש, כדור 5 מג של חומצה פולית ביום למשך חודש \n" + count2);
                count2++;
                richTextBox2.AppendText("אנטיביוטיקה ייעודית\n" + count2);
                count2++;
                richTextBox2.AppendText("אנטרקטיניב - Entrectinib\n" + count2);
                count2++;
            }
            
            if (52 < patient1.Lymph)
            {
                richTextBox1.AppendText(count + ".ערך גבוה של לימפוציטים עשויים להצביע על זיהום חיידקי ממושך או על סרטן הלימפומה.\n");
                count++;
                richTextBox2.AppendText("אנטיביוטיקה ייעודית\n" + count2);
                count2++;
                richTextBox2.AppendText("אנטרקטיניב - Entrectinib\n" + count2);
                count2++;
            }

            if (36 < patient1.Lymph)
            {
                richTextBox1.AppendText(count + ".ערך נמוך של לימפוציטים מעידים על בעיה ביצירת תאי הדם.\n");
                count++;
                richTextBox2.AppendText("כדור 10 מג של בי-12 ביום למשך חודש, כדור 5 מג של חומצה פולית ביום למשך חודש \n" + count2);
                count2++;
            }
            if (6 < patient1.RBC)
            {
                richTextBox1.AppendText(count + ".קיים ערך גבוה של כדוריות הדם האדומות אחראיות על קשירת חמצן מהריאות עלולים להצביע על הפרעה במערכת ייצור הדם. רמות גבוהות נצפו גם אצל מעשנים ואצל חולים במחלת ריאות.\n");
                count++;
                richTextBox2.AppendText("כדור 10 מג של בי-12 ביום למשך חודש, כדור 5 מג של חומצה פולית ביום למשך חודש \n" + count2);
                count2++;
                richTextBox2.AppendText("להפסיק לעשן \n" + count2);
                count2++;
                richTextBox2.AppendText("הפניה לצילום רנטגן של הראות \n" + count2);
                count2++;
            }

            if (4.5 < patient1.RBC)
            {
                richTextBox1.AppendText(count + ".קיים ערך נמוך של כדוריות הדם האדומות אחראיות על קשירת חמצן מהריאות העלולים להצביע על אנמיה או על דימומים קשים.\n");
                count++;
                richTextBox2.AppendText("שני כדורי 10 מג של בי-12 ביום למשך חודש \n" + count2);
                count2++;
                richTextBox2.AppendText("להתפנות בדחיפות לבית החולים \n" + count2);
                count2++;
            }
            if (54 < patient1.HCT || 37 > patient1.HCT)
            {
                if (patient1.sex == "male")
                {
                    if (54 < patient1.HCT)
                    {
                        richTextBox1.AppendText(count + ".קיים ערך גבוה של נפח כדוריות הדם האדומות  דבר זה שכיח בדרך כלל אצל מעשנים.\n");
                        count++;
                        richTextBox2.AppendText("להפסיק לעשן \n" + count2);
                        count2++;

                    }
                    if (37 > patient1.HCT)
                    {
                        richTextBox1.AppendText(count + ".קיים ערך נמוך של נפח כדוריות הדם האדומות אשר מצביע לרוב על דימום או על אנמיה.\n");
                        count++;
                        richTextBox2.AppendText("שני כדורי 10 מג של בי-12 ביום למשך חודש \n" + count2);
                        count2++;
                        richTextBox2.AppendText("להתפנות בדחיפות לבית חולים \n" + count2);
                        count2++;
                    }
                }
                else
                {
                    if (47 < patient1.HCT)
                    {
                        richTextBox1.AppendText(count + ".קיים ערך גבוה של נפח כדוריות הדם האדומות  דבר זה שכיח בדרך כלל אצל מעשנים.\n");
                        count++;
                        richTextBox2.AppendText("להפסיק לעשן \n" + count2);
                        count2++;
                    }
                    if (33 > patient1.HCT)
                    {
                        richTextBox1.AppendText(count + ".קיים ערך נמוך של נפח כדוריות הדם האדומות אשר מצביע לרוב על דימום או על אנמיה.\n");
                        count++;
                        richTextBox2.AppendText("שני כדורי 10 מג של בי-12 ביום למשך חודש \n" + count2);
                        count2++;
                        richTextBox2.AppendText("להתפנות בדחיפות לבית חולים \n" + count2);
                        count2++;
                    }
                }
            }

            if (43 < patient1.Urea)
            {
                if (patient1.origin == 2 && 47.3 < patient1.Urea)
                {
                    richTextBox1.AppendText(count + ".קיים ערך גבוה של רמת השתנן בדם אשר עלולים להצביע על מחלות כליה, התייבשות או דיאטה עתירת חלבונים.\n");
                    count++;
                    richTextBox2.AppendText("לתאם פגישה עם תזונאי \n" + count2);
                    count2++;
                    richTextBox2.AppendText("מנוחה מוחלטת בשכיבה, החזרת נוזלים בשתייה \n" + count2);
                    count2++;
                    richTextBox2.AppendText("איזון רמות הסוכר בדם \n" + count2);
                    count2++;
                }
                else
                {
                    richTextBox1.AppendText(count + ".קיים ערך גבוה של רמת השתנן בדם אשר עלולים להצביע על מחלות כליה, התייבשות או דיאטה עתירת חלבונים.\n");
                    count++;
                    richTextBox2.AppendText("לתאם פגישה עם תזונאי \n" + count2);
                    count2++;
                    richTextBox2.AppendText("מנוחה מוחלטת בשכיבה, החזרת נוזלים בשתייה \n" + count2);
                    count2++;
                    richTextBox2.AppendText("איזון רמות הסוכר בדם \n" + count2);
                    count2++;
                }

            }
            if (17 > patient1.Urea)
            {
                if (patient1.origin == 2 && 38.7 > patient1.Urea)
                {
                    richTextBox1.AppendText(count + ".קיים ערך נמוך של רמת השתנן בדם אשר מצביעים על  תת תזונה, דיאטה דלת חלבון או מחלת כבד. יש לציין שבהריון רמת השתנן יורדת.\n");
                    count++;
                    richTextBox2.AppendText("לתאם פגישה עם תזונאי \n" + count2);
                    count2++;
                    richTextBox2.AppendText("הפניה לאבחנה ספציפית לצורך קביעת טיפול \n" + count2);
                    count2++;
                }
                else
                {
                    richTextBox1.AppendText(count + ".קיים ערך נמוך של רמת השתנן בדם אשר מצביעים על  תת תזונה, דיאטה דלת חלבון או מחלת כבד. יש לציין שבהריון רמת השתנן יורדת.\n");
                    count++;
                    richTextBox2.AppendText("לתאם פגישה עם תזונאי \n" + count2);
                    count2++;
                    richTextBox2.AppendText("הפניה לאבחנה ספציפית לצורך קביעת טיפול \n" + count2);
                    count2++;
                }
            }

            if (patient1.sex == "man")
            {
                if (18 < patient1.Hb)
                {
                    richTextBox1.AppendText(count + ".קיים ערך גבוה של מוגלובין ערכים גבוהים מהנורמה יכולים להצביע על ריבוי של תאי דם אדומים (פוליציטמיה). המצב הזה שכיח בדרך כלל אצל מעשנים ואצל חולים במחלות־ריאה או במחלות של מוח־העצם.  .\n");
                    count++;
                }
                
                if (12 > patient1.Hb)
                {
                    richTextBox1.AppendText(count + ".קיים ערך נמוך של מוגלובין אשר מעידים על אנמיה.זו יכולה לנבוע מהפרעה המטולוגית, ממחסור בברזל ומדימומים.\n");
                    count++;
                    richTextBox2.AppendText("שני כדורי 10 מג של בי-12 ביום למשך חודש \n" + count2);
                    count2++;
                    richTextBox2.AppendText("להתפנות בדחיפות לבית חולים \n" + count2);
                    count2++;
                    richTextBox2.AppendText("זריקה של הורמון לעידוד ייצור תאי הדם האדומים \n" + count2);
                    count2++;
                }
            }
            else
            {
                if (16 < patient1.Hb)
                {
                    richTextBox1.AppendText(count + ".קיים ערך גבוה של מוגלובין ערכים גבוהים מהנורמה יכולים להצביע על ריבוי של תאי דם אדומים (פוליציטמיה). המצב הזה שכיח בדרך כלל אצל מעשנים ואצל חולים במחלות־ריאה או במחלות של מוח־העצם.  .\n");
                    count++;
                }
                if (12 > patient1.Hb)
                {
                    richTextBox1.AppendText(count + ".קיים ערך נמוך של מוגלובין אשר מעידים על אנמיה.זו יכולה לנבוע מהפרעה המטולוגית, ממחסור בברזל ומדימומים.\n");
                    count++;
                    richTextBox2.AppendText("שני כדורי 10 מג של בי-12 ביום למשך חודש \n" + count2);
                    count2++;
                    richTextBox2.AppendText("להתפנות בדחיפות לבית חולים \n" + count2);
                    count2++;
                    richTextBox2.AppendText("זריקה של הורמון לעידוד ייצור תאי הדם האדומים \n" + count2);
                    count2++;
                }
            }

            if(patient1.age > 59)
            {
                if (1.2 < patient1.Crtn)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של קריטאינין ערכים גבוהים מהנורמה עלולים להצביע על בעיה כלייתית ובמקרים חמורים על אי ספיקת כליות. ערכים גבוהים ניתן למצוא גם בעת שלשולים והקאות (הגורמים לפירוק מוגבר של שריר ולערכים גבוהים של קריאטינין), מחלות שריר וצריכה מוגברת של בשר.\n");
                    count++;
                    richTextBox2.AppendText("שני כדורי 5 מג של כורכום כי-3 של אלטמן ביום למשך חודש \n" + count2);
                    count2++;
                    richTextBox2.AppendText("לתאם פגישה עם תזונאית \n" + count2);
                    count2++;
                }
                if (0.6 > patient1.Crtn)
                {
                    richTextBox1.AppendText(count + ".קיים ערך נמוך של קריטאינין אשר נראים לרוב בחולים בעלי מסת שריר ירודה מאוד ואנשים בתת תזונה שאינם צורכים די חלבון.\n");
                    count++;
                    richTextBox2.AppendText("לתאם פגישה עם תזונאית \n" + count2);
                    count2++;
                }
            }
            else
            {
                if (1 < patient1.Crtn)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של קריטאינין ערכים גבוהים מהנורמה עלולים להצביע על בעיה כלייתית ובמקרים חמורים על אי ספיקת כליות. ערכים גבוהים ניתן למצוא גם בעת שלשולים והקאות (הגורמים לפירוק מוגבר של שריר ולערכים גבוהים של קריאטינין), מחלות שריר וצריכה מוגברת של בשר.\n");
                    count++;
                    richTextBox2.AppendText("שני כדורי 5 מג של כורכום כי-3 של אלטמן ביום למשך חודש \n" + count2);
                    count2++;
                    richTextBox2.AppendText("לתאם פגישה עם תזונאית \n" + count2);
                    count2++;
                }
                if (0.6 > patient1.Crtn)
                {
                    richTextBox1.AppendText(count + ".קיים ערך נמוך של קריטאינין אשר נראים לרוב בחולים בעלי מסת שריר ירודה מאוד ואנשים בתת תזונה שאינם צורכים די חלבון.\n");
                    count++;
                    richTextBox2.AppendText("לתאם פגישה עם תזונאית \n" + count2);
                    count2++;
                }
            }

            if (patient1.sex == "man")
            {
                if (160 < patient1.Iron)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של ברזל ערכים גבוהים עלולים להצביע על הרעלת ברזל. \n");
                    count++;
                    richTextBox2.AppendText(" להתפנות לבית חולים \n" + count2);
                    count2++;
                }
                if (60 > patient1.Iron)
                {
                    richTextBox1.AppendText(count + ". קיים ערך נמוך של ברזל אשר מעיד בדרך כלל על תזונה לא מספקת או על עלייה בצורך בברזל (למשל בהריון) או על איבוד דם בעקבות דימום. \n");
                    count++;
                    richTextBox2.AppendText(" להתפנות לבית חולים \n" + count2);
                    count2++;
                    richTextBox2.AppendText("שני כדורי 10 מג של בי-12 ביום למשך חודש \n" + count2);
                    count2++;
                }
            }
            else
            {
                if (96 < patient1.Iron)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של ברזל ערכים גבוהים עלולים להצביע על הרעלת ברזל. \n");
                    count++;
                    richTextBox2.AppendText(" להתפנות לבית חולים \n" + count2);
                    count2++;
                }
                if (48 > patient1.Iron)
                {
                    richTextBox1.AppendText(count + ". קיים ערך נמוך של ברזל אשר מעיד בדרך כלל על תזונה לא מספקת או על עלייה בצורך בברזל (למשל בהריון) או על איבוד דם בעקבות דימום. \n");
                    count++;
                    richTextBox2.AppendText(" להתפנות לבית חולים \n" + count2);
                    count2++;
                    richTextBox2.AppendText("שני כדורי 10 מג של בי-12 ביום למשך חודש \n" + count2);
                    count2++;
                }
            }
            if (patient1.sex == "man")
            {
                
                if (62 < patient1.HDL)
                {
                    if(patient1.origin == 0 && 74.4 < patient1.HDL)
                    {
                        richTextBox1.AppendText(count + ". קיים ערך גבוה של 'הכולסטרול הטוב', הינו מולקולה דמוית חלבון ערכים גבוהים : לרוב אינן מזיקות. פעילות גופנית מעלה את רמות הכולסטרול הטוב. \n");
                        count++;
                    }
                }
                if (29 > patient1.HDL)
                {
                    if (patient1.origin == 0 && 23.2 > patient1.HDL)
                    {
                        richTextBox1.AppendText(count + ". קיים ערך נמוך של 'הכולסטרול הטוב', הינו מולקולה דמוית חלבון ערכים נמוכים עשויים להצביע על סיכון למחלות לב, על היפרליפידמיה )יתר שומנים בדם( או על סוכרת מבוגרים . \n");
                        count++;
                        richTextBox2.AppendText(" לתאם פגישה עם תזונאי, כדור 5 מג של סימוביל ביום למשך שבוע \n" + count2);
                        count2++;
                        richTextBox2.AppendText(" התאמת אינסולין למטופל \n" + count2);
                        count2++;
                    }
                }
            }
            else
            {
                if (82 < patient1.HDL)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של 'הכולסטרול הטוב', הינו מולקולה דמוית חלבון ערכים גבוהים : לרוב אינן מזיקות. פעילות גופנית מעלה את רמות הכולסטרול הטוב. \n");
                    count++;
                }
                if (34 > patient1.HDL)
                {
                    richTextBox1.AppendText(count + ". קיים ערך נמוך של 'הכולסטרול הטוב', הינו מולקולה דמוית חלבון ערכים נמוכים עשויים להצביע על סיכון למחלות לב, על היפרליפידמיה )יתר שומנים בדם( או על סוכרת מבוגרים . \n");
                    count++;
                    richTextBox2.AppendText(" לתאם פגישה עם תזונאי, כדור 5 מג של סימוביל ביום למשך שבוע \n" + count2);
                    count2++;
                    richTextBox2.AppendText(" התאמת אינסולין למטופל \n" + count2);
                    count2++;
                }
            }
            if (patient1.origin == 2)
            {
                if (120 < patient1.AP)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של פוסםטזה אלקלית עלול להצביע על מחלות כבד, מחלות בדרכי המרה, הריון, פעילות יתר של בלוטת התריס או שימוש בתרופות שונות. \n");
                    count++;
                    richTextBox2.AppendText(" הפניה לטיופל חירוגי \n" + count2);
                    count2++;
                    richTextBox2.AppendText(" הפניה לרופא המשפחה לצורך התאמה בין התרופות \n" + count2);
                    count2++;
                    richTextBox2.AppendText(" Propylthiouracil להקטנת פעילות בלוטת התריס \n" + count2);
                    count2++;
                }
                if (60 > patient1.AP)
                {
                    richTextBox1.AppendText(count + ". ויטמין B6 חומצה פולית. ,B12ויטמין ,C  קיים ערך נמוך של פוסםטזה אלקלית עלול להצביע על על תזונה לקויה שחסרים בה חלבונים. חוסר בוויטמינים כמו ויטמין . \n");
                    count++;
                    richTextBox2.AppendText(" הפניה לבדיקת דם לזיהוי הויטמינים החסרים  \n" + count2);
                    count2++;
                }
            }
            else
            {
                if (90 < patient1.AP)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של פוסםטזה אלקלית עלול להצביע על מחלות כבד, מחלות בדרכי המרה, הריון, פעילות יתר של בלוטת התריס או שימוש בתרופות שונות. \n");
                    count++;
                    richTextBox2.AppendText(" הפניה לטיופל חירוגי \n" + count2);
                    count2++;
                    richTextBox2.AppendText(" הפניה לרופא המשפחה לצורך התאמה בין התרופות \n" + count2);
                    count2++;
                    richTextBox2.AppendText(" Propylthiouracil להקטנת פעילות בלוטת התריס \n" + count2);
                    count2++;
                }
                if (30 > patient1.AP)
                {
                    richTextBox1.AppendText(count + ". ויטמין B6 חומצה פולית. ,B12ויטמין ,C  קיים ערך נמוך של פוסםטזה אלקלית עלול להצביע על על תזונה לקויה שחסרים בה חלבונים. חוסר בוויטמינים כמו ויטמין . \n");
                    count++;
                    richTextBox2.AppendText(" הפניה לבדיקת דם לזיהוי הויטמינים החסרים  \n" + count2);
                    count2++;
                }
            }
            patient1.setdi(richTextBox1.Text);
            patient1.setse(richTextBox2.Text);
        }
        public void analysisForChildren()
        {
            int count = 1;
            int count2 = 1;
            if (15500 > patient1.WBC)
            {
                richTextBox1.AppendText(count + ".ות על קיומו של זיהום, אם קיימת מחלת חום. במקרים אחרים, נדירים ביותר, עלולים ערכים גבוהים מאוד להעיד על מחלת דם או סרטן\n");
                count++;
                richTextBox2.AppendText("שילוב של ציקלופוספאמיד וקורטיקוסרואידים\n" + count2);
                count2++;
                richTextBox2.AppendText("אנטרקטיניב - Entrectinib\n" + count2);
                count2++;
                richTextBox2.AppendText("אנטיביוטיקה ייעודית\n" + count2);
                count2++;
            }
            if (5500 < patient1.WBC)
            {
                richTextBox1.AppendText(count + ". קיים ערך נמוך של כדורי דם לבנים היכול להצביע על מחלה ויראלית, כשל של מערכת החיסון ובמקרים נדירים ביותר על סרטן\n");
                count++;
                richTextBox2.AppendText("לנוח בבית\n" + count2);
                count2++;
                richTextBox2.AppendText("אנטרקטיניב - Entrectinib\n" + count2);
                count2++;
            }

            if (54 < patient1.Neut)
            {
                richTextBox1.AppendText(count + ".ערך גבוה של נויטרופיל מעידים לרוב על זיהום חיידקי.\n");
                count++;
                richTextBox2.AppendText("אנטיביוטיקה ייעודית\n" + count2);
                count2++;
            }

            if (28 < patient1.Neut)
            {
                richTextBox1.AppendText(count + ".ערך נמוך של נויטרופיל מעידים על הפרעה ביצירת הדם, על נטייה לזיהומים מחיידקים ובמקרים נדירים - על תהליך סרטני.\n");
                count++;
                richTextBox2.AppendText("כדור 10 מג של בי-12 ביום למשך חודש, כדור 5 מג של חומצה פולית ביום למשך חודש \n" + count2);
                count2++;
                richTextBox2.AppendText("כדור 10 מג של בי-12 ביום למשך חודש, כדור 5 מג של חומצה פולית ביום למשך חודש \n" + count2);
                count2++;
                richTextBox2.AppendText("אנטיביוטיקה ייעודית\n" + count2);
                count2++;
                richTextBox2.AppendText("אנטרקטיניב - Entrectinib\n" + count2);
                count2++;
            }

            if (52 < patient1.Lymph)
            {
                richTextBox1.AppendText(count + ".ערך גבוה של לימפוציטים עשויים להצביע על זיהום חיידקי ממושך או על סרטן הלימפומה.\n");
                count++;
                richTextBox2.AppendText("אנטיביוטיקה ייעודית\n" + count2);
                count2++;
                richTextBox2.AppendText("אנטרקטיניב - Entrectinib\n" + count2);
                count2++;
            }

            if (36 < patient1.Lymph)
            {
                richTextBox1.AppendText(count + ".ערך נמוך של לימפוציטים מעידים על בעיה ביצירת תאי הדם.\n");
                count++;
                richTextBox2.AppendText("כדור 10 מג של בי-12 ביום למשך חודש, כדור 5 מג של חומצה פולית ביום למשך חודש \n" + count2);
                count2++;
            }
            if (6 < patient1.RBC)
            {
                richTextBox1.AppendText(count + ".קיים ערך גבוה של כדוריות הדם האדומות אחראיות על קשירת חמצן מהריאות עלולים להצביע על הפרעה במערכת ייצור הדם. רמות גבוהות נצפו גם אצל מעשנים ואצל חולים במחלת ריאות.\n");
                count++;
                richTextBox2.AppendText("כדור 10 מג של בי-12 ביום למשך חודש, כדור 5 מג של חומצה פולית ביום למשך חודש \n" + count2);
                count2++;
                richTextBox2.AppendText("להפסיק לעשן \n" + count2);
                count2++;
                richTextBox2.AppendText("הפניה לצילום רנטגן של הראות \n" + count2);
                count2++;
            }

            if (4.5 < patient1.RBC)
            {
                richTextBox1.AppendText(count + ".קיים ערך נמוך של כדוריות הדם האדומות אחראיות על קשירת חמצן מהריאות העלולים להצביע על אנמיה או על דימומים קשים.\n");
                count++;
                richTextBox2.AppendText("שני כדורי 10 מג של בי-12 ביום למשך חודש \n" + count2);
                count2++;
                richTextBox2.AppendText("להתפנות בדחיפות לבית החולים \n" + count2);
                count2++;
            }
            if (54 < patient1.HCT || 37 > patient1.HCT)
            {
                if (patient1.sex == "male")
                {
                    if (54 < patient1.HCT)
                    {
                        richTextBox1.AppendText(count + ".קיים ערך גבוה של נפח כדוריות הדם האדומות  דבר זה שכיח בדרך כלל אצל מעשנים.\n");
                        count++;
                        richTextBox2.AppendText("להפסיק לעשן \n" + count2);
                        count2++;
                    }
                    if (37 > patient1.HCT)
                    {
                        richTextBox1.AppendText(count + ".קיים ערך נמוך של נפח כדוריות הדם האדומות אשר מצביע לרוב על דימום או על אנמיה.\n");
                        count++;
                        richTextBox2.AppendText("שני כדורי 10 מג של בי-12 ביום למשך חודש \n" + count2);
                        count2++;
                        richTextBox2.AppendText("להתפנות בדחיפות לבית חולים \n" + count2);
                        count2++;
                    }
                }
                else
                {
                    if (47 < patient1.HCT)
                    {
                        richTextBox1.AppendText(count + ".קיים ערך גבוה של נפח כדוריות הדם האדומות  דבר זה שכיח בדרך כלל אצל מעשנים.\n");
                        count++;
                        richTextBox2.AppendText("להפסיק לעשן \n" + count2);
                        count2++;
                    }
                    if (33 > patient1.HCT)
                    {
                        richTextBox1.AppendText(count + ".קיים ערך נמוך של נפח כדוריות הדם האדומות אשר מצביע לרוב על דימום או על אנמיה.\n");
                        count++;
                        richTextBox2.AppendText("שני כדורי 10 מג של בי-12 ביום למשך חודש \n" + count2);
                        count2++;
                        richTextBox2.AppendText("להתפנות בדחיפות לבית חולים \n" + count2);
                        count2++;
                    }
                }
            }
            if (43 < patient1.Urea)
            {
                if (patient1.origin == 2 && 47.3 < patient1.Urea)
                {
                    richTextBox1.AppendText(count + ".קיים ערך גבוה של רמת השתנן בדם אשר עלולים להצביע על מחלות כליה, התייבשות או דיאטה עתירת חלבונים.\n");
                    count++;
                    richTextBox2.AppendText("לתאם פגישה עם תזונאי \n" + count2);
                    count2++;
                    richTextBox2.AppendText("הפניה לאבחנה ספציפית לצורך קביעת טיפול \n" + count2);
                    count2++;
                }
                else
                {
                    richTextBox1.AppendText(count + ".קיים ערך גבוה של רמת השתנן בדם אשר עלולים להצביע על מחלות כליה, התייבשות או דיאטה עתירת חלבונים.\n");
                    count++;
                    richTextBox2.AppendText("לתאם פגישה עם תזונאי \n" + count2);
                    count2++;
                    richTextBox2.AppendText("הפניה לאבחנה ספציפית לצורך קביעת טיפול \n" + count2);
                    count2++;
                }

            }
            if (17 > patient1.Urea)
            {
                if (patient1.origin == 2 && 38.7 > patient1.Urea)
                {
                    richTextBox1.AppendText(count + ".קיים ערך נמוך של רמת השתנן בדם אשר מצביעים על  תת תזונה, דיאטה דלת חלבון או מחלת כבד. יש לציין שבהריון רמת השתנן יורדת.\n");
                    count++;
                    richTextBox2.AppendText("לתאם פגישה עם תזונאי \n" + count2);
                    count2++;
                    richTextBox2.AppendText("הפניה לאבחנה ספציפית לצורך קביעת טיפול \n" + count2);
                    count2++;
                }
                else
                {
                    richTextBox1.AppendText(count + ".קיים ערך נמוך של רמת השתנן בדם אשר מצביעים על  תת תזונה, דיאטה דלת חלבון או מחלת כבד. יש לציין שבהריון רמת השתנן יורדת.\n");
                    count++;
                    richTextBox2.AppendText("לתאם פגישה עם תזונאי \n" + count2);
                    count2++;
                    richTextBox2.AppendText("הפניה לאבחנה ספציפית לצורך קביעת טיפול \n" + count2);
                    count2++;
                }
            }

            if (15.5 < patient1.Hb)
            {
                richTextBox1.AppendText(count + ".קיים ערך גבוה של מוגלובין ערכים גבוהים מהנורמה יכולים להצביע על ריבוי של תאי דם אדומים (פוליציטמיה). המצב הזה שכיח בדרך כלל אצל מעשנים ואצל חולים במחלות־ריאה או במחלות של מוח־העצם.  .\n");
                count++;
            }
            if (11.5 > patient1.Hb)
            {
                richTextBox1.AppendText(count + ".קיים ערך נמוך של מוגלובין אשר מעידים על אנמיה.זו יכולה לנבוע מהפרעה המטולוגית, ממחסור בברזל ומדימומים.\n");
                count++;
                richTextBox2.AppendText("שני כדורי 10 מג של בי-12 ביום למשך חודש \n" + count2);
                count2++;
                richTextBox2.AppendText("להתפנות בדחיפות לבית חולים \n" + count2);
                count2++;
                richTextBox2.AppendText("זריקה של הורמון לעידוד ייצור תאי הדם האדומים \n" + count2);
                count2++;
            }
            if (1 < patient1.Crtn)
            {
                richTextBox1.AppendText(count + ". קיים ערך גבוה של קריטאינין ערכים גבוהים מהנורמה עלולים להצביע על בעיה כלייתית ובמקרים חמורים על אי ספיקת כליות. ערכים גבוהים ניתן למצוא גם בעת שלשולים והקאות (הגורמים לפירוק מוגבר של שריר ולערכים גבוהים של קריאטינין), מחלות שריר וצריכה מוגברת של בשר.\n");
                count++;
                richTextBox2.AppendText("שני כדורי 5 מג של כורכום כי-3 של אלטמן ביום למשך חודש \n" + count2);
                count2++;
                richTextBox2.AppendText("לתאם פגישה עם תזונאית \n" + count2);
                count2++;
            }
            if (0.5 > patient1.Crtn)
            {
                richTextBox1.AppendText(count + ".קיים ערך נמוך של קריטאינין אשר נראים לרוב בחולים בעלי מסת שריר ירודה מאוד ואנשים בתת תזונה שאינם צורכים די חלבון.\n");
                count++;
                richTextBox2.AppendText("לתאם פגישה עם תזונאית \n" + count2);
                count2++;
            }
            if (patient1.sex == "man")
            {
                if (160 < patient1.Iron)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של ברזל ערכים גבוהים עלולים להצביע על הרעלת ברזל. \n");
                    count++;
                    richTextBox2.AppendText(" להתפנות לבית חולים \n" + count2);
                    count2++;
                }
                if (60 > patient1.Iron)
                {
                    richTextBox1.AppendText(count + ". קיים ערך נמוך של ברזל אשר מעיד בדרך כלל על תזונה לא מספקת או על עלייה בצורך בברזל (למשל בהריון) או על איבוד דם בעקבות דימום. \n");
                    count++;
                    richTextBox2.AppendText(" להתפנות לבית חולים \n" + count2);
                    count2++;
                    richTextBox2.AppendText("שני כדורי 10 מג של בי-12 ביום למשך חודש \n" + count2);
                    count2++;
                }
            }
            else
            {
                if (96 < patient1.Iron)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של ברזל ערכים גבוהים עלולים להצביע על הרעלת ברזל. \n");
                    count++;
                    richTextBox2.AppendText(" להתפנות לבית חולים \n" + count2);
                    count2++;
                }
                if (48 > patient1.Iron)
                {
                    richTextBox1.AppendText(count + ". קיים ערך נמוך של ברזל אשר מעיד בדרך כלל על תזונה לא מספקת או על עלייה בצורך בברזל (למשל בהריון) או על איבוד דם בעקבות דימום. \n");
                    count++;
                }
            }
            if (patient1.sex == "man")
            {
                if (62 < patient1.HDL)
                {
                    if (patient1.origin == 0 && 74.4 < patient1.HDL)
                    {
                        richTextBox1.AppendText(count + ". קיים ערך גבוה של 'הכולסטרול הטוב', הינו מולקולה דמוית חלבון ערכים גבוהים : לרוב אינן מזיקות. פעילות גופנית מעלה את רמות הכולסטרול הטוב. \n");
                        count++;
                    }
                }
                if (29 > patient1.HDL)
                {
                    if (patient1.origin == 0 && 23.2 > patient1.HDL)
                    {
                        richTextBox1.AppendText(count + ". קיים ערך נמוך של 'הכולסטרול הטוב', הינו מולקולה דמוית חלבון ערכים נמוכים עשויים להצביע על סיכון למחלות לב, על היפרליפידמיה )יתר שומנים בדם( או על סוכרת מבוגרים . \n");
                        count++;
                        richTextBox2.AppendText(" לתאם פגישה עם תזונאי, כדור 5 מג של סימוביל ביום למשך שבוע \n" + count2);
                        count2++;
                        richTextBox2.AppendText(" התאמת אינסולין למטופל \n" + count2);
                        count2++;
                    }
                    else
                    {
                        richTextBox1.AppendText(count + ". קיים ערך נמוך של 'הכולסטרול הטוב', הינו מולקולה דמוית חלבון ערכים נמוכים עשויים להצביע על סיכון למחלות לב, על היפרליפידמיה )יתר שומנים בדם( או על סוכרת מבוגרים . \n");
                        count++;
                        richTextBox2.AppendText(" לתאם פגישה עם תזונאי, כדור 5 מג של סימוביל ביום למשך שבוע \n" + count2);
                        count2++;
                        richTextBox2.AppendText(" התאמת אינסולין למטופל \n" + count2);
                        count2++;
                    }
                }
            }
            else
            {
                if (82 < patient1.HDL)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של 'הכולסטרול הטוב', הינו מולקולה דמוית חלבון ערכים גבוהים : לרוב אינן מזיקות. פעילות גופנית מעלה את רמות הכולסטרול הטוב. \n");
                    count++;
                }
                if (34 > patient1.HDL)
                {
                    richTextBox1.AppendText(count + ". קיים ערך נמוך של 'הכולסטרול הטוב', הינו מולקולה דמוית חלבון ערכים נמוכים עשויים להצביע על סיכון למחלות לב, על היפרליפידמיה )יתר שומנים בדם( או על סוכרת מבוגרים . \n");
                    count++;
                    richTextBox2.AppendText(" לתאם פגישה עם תזונאי, כדור 5 מג של סימוביל ביום למשך שבוע \n" + count2);
                    count2++;
                    richTextBox2.AppendText(" התאמת אינסולין למטופל \n" + count2);
                    count2++;
                }
            }
            if (patient1.origin == 2)
            {
                if (120 < patient1.AP)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של פוסםטזה אלקלית עלול להצביע על מחלות כבד, מחלות בדרכי המרה, הריון, פעילות יתר של בלוטת התריס או שימוש בתרופות שונות. \n");
                    count++;
                    richTextBox2.AppendText(" הפניה לטיופל חירוגי \n" + count2);
                    count2++;
                    richTextBox2.AppendText(" הפניה לרופא המשפחה לצורך התאמה בין התרופות \n" + count2);
                    count2++;
                    richTextBox2.AppendText(" Propylthiouracil להקטנת פעילות בלוטת התריס \n" + count2);
                    count2++;
                }
                if (60 > patient1.AP)
                {
                    richTextBox1.AppendText(count + ". ויטמין B6 חומצה פולית. ,B12ויטמין ,C  קיים ערך נמוך של פוסםטזה אלקלית עלול להצביע על על תזונה לקויה שחסרים בה חלבונים. חוסר בוויטמינים כמו ויטמין . \n");
                    count++;
                    richTextBox2.AppendText(" הפניה לבדיקת דם לזיהוי הויטמינים החסרים  \n" + count2);
                    count2++;
                }
            }
            else
            {
                if (90 < patient1.AP)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של פוסםטזה אלקלית עלול להצביע על מחלות כבד, מחלות בדרכי המרה, הריון, פעילות יתר של בלוטת התריס או שימוש בתרופות שונות. \n");
                    count++;
                    richTextBox2.AppendText(" הפניה לטיופל חירוגי \n" + count2);
                    count2++;
                    richTextBox2.AppendText(" הפניה לרופא המשפחה לצורך התאמה בין התרופות \n" + count2);
                    count2++;
                    richTextBox2.AppendText(" Propylthiouracil להקטנת פעילות בלוטת התריס \n" + count2);
                    count2++;
                }
                if (30 > patient1.AP)
                {
                    richTextBox1.AppendText(count + ". ויטמין B6 חומצה פולית. ,B12ויטמין ,C  קיים ערך נמוך של פוסםטזה אלקלית עלול להצביע על על תזונה לקויה שחסרים בה חלבונים. חוסר בוויטמינים כמו ויטמין . \n");
                    count++;
                    richTextBox2.AppendText(" הפניה לבדיקת דם לזיהוי הויטמינים החסרים  \n" + count2);
                    count2++;
                }
            }
            patient1.setdi(richTextBox1.Text);
            patient1.setse(richTextBox2.Text);
        }
        public void analysisForbaby()
        {
            int count = 1;
            int count2 = 1;
            if (17500 > patient1.WBC)
            {
                richTextBox1.AppendText(count + ".ות על קיומו של זיהום, אם קיימת מחלת חום. במקרים אחרים, נדירים ביותר, עלולים ערכים גבוהים מאוד להעיד על מחלת דם או סרטן\n");
                count++;
                richTextBox2.AppendText("שילוב של ציקלופוספאמיד וקורטיקוסרואידים\n" + count2);
                count2++;
                richTextBox2.AppendText("אנטרקטיניב - Entrectinib\n" + count2);
                count2++;
                richTextBox2.AppendText("אנטיביוטיקה ייעודית\n" + count2);
                count2++;
            }
            if (6000 < patient1.WBC)
            {
                richTextBox1.AppendText(count + ". קיים ערך נמוך של כדורי דם לבנים היכול להצביע על מחלה ויראלית, כשל של מערכת החיסון ובמקרים נדירים ביותר על סרטן\n");
                count++;
                richTextBox2.AppendText("לנוח בבית\n" + count2);
                count2++;
                richTextBox2.AppendText("אנטרקטיניב - Entrectinib\n" + count2);
                count2++;
            }

            if (54 < patient1.Neut)
            {
                richTextBox1.AppendText(count + ".ערך גבוה של נויטרופיל מעידים לרוב על זיהום חיידקי.\n");
                count++;
                richTextBox2.AppendText("אנטיביוטיקה ייעודית\n" + count2);
                count2++;

            }

            if (28 < patient1.Neut)
            {
                richTextBox1.AppendText(count + ".ערך נמוך של נויטרופיל מעידים על הפרעה ביצירת הדם, על נטייה לזיהומים מחיידקים ובמקרים נדירים - על תהליך סרטני.\n");
                count++;
                richTextBox2.AppendText("כדור 10 מג של בי-12 ביום למשך חודש, כדור 5 מג של חומצה פולית ביום למשך חודש \n" + count2);
                count2++;
                richTextBox2.AppendText("כדור 10 מג של בי-12 ביום למשך חודש, כדור 5 מג של חומצה פולית ביום למשך חודש \n" + count2);
                count2++;
                richTextBox2.AppendText("אנטיביוטיקה ייעודית\n" + count2);
                count2++;
                richTextBox2.AppendText("אנטרקטיניב - Entrectinib\n" + count2);
                count2++;
            }

            if (52 < patient1.Lymph)
            {
                richTextBox1.AppendText(count + ".ערך גבוה של לימפוציטים עשויים להצביע על זיהום חיידקי ממושך או על סרטן הלימפומה.\n");
                count++;
                richTextBox2.AppendText("אנטיביוטיקה ייעודית\n" + count2);
                count2++;
                richTextBox2.AppendText("אנטרקטיניב - Entrectinib\n" + count2);
                count2++;
            }

            if (36 > patient1.Lymph)
            {
                richTextBox1.AppendText(count + ".ערך נמוך של לימפוציטים מעידים על בעיה ביצירת תאי הדם.\n");
                count++;
                richTextBox2.AppendText("כדור 10 מג של בי-12 ביום למשך חודש, כדור 5 מג של חומצה פולית ביום למשך חודש \n" + count2);
                count2++;
            }
            if (6 < patient1.RBC)
            {
                richTextBox1.AppendText(count + ".קיים ערך גבוה של כדוריות הדם האדומות אחראיות על קשירת חמצן מהריאות עלולים להצביע על הפרעה במערכת ייצור הדם. רמות גבוהות נצפו גם אצל מעשנים ואצל חולים במחלת ריאות.\n");
                count++;
                richTextBox2.AppendText("כדור 10 מג של בי-12 ביום למשך חודש, כדור 5 מג של חומצה פולית ביום למשך חודש \n" + count2);
                count2++;
                richTextBox2.AppendText("להפסיק לעשן \n" + count2);
                count2++;
                richTextBox2.AppendText("הפניה לצילום רנטגן של הראות \n" + count2);
                count2++;
            }

            if (4.5 < patient1.RBC)
            {
                richTextBox1.AppendText(count + ".קיים ערך נמוך של כדוריות הדם האדומות אחראיות על קשירת חמצן מהריאות העלולים להצביע על אנמיה או על דימומים קשים.\n");
                count++;
                richTextBox2.AppendText("שני כדורי 10 מג של בי-12 ביום למשך חודש \n" + count2);
                count2++;
                richTextBox2.AppendText("להתפנות בדחיפות לבית החולים \n" + count2);
                count2++;
            }
            if (54 < patient1.HCT || 37 > patient1.HCT)
            {
                if (patient1.sex == "male")
                {
                    if (54 < patient1.HCT)
                    {
                        richTextBox1.AppendText(count + ".קיים ערך גבוה של נפח כדוריות הדם האדומות  דבר זה שכיח בדרך כלל אצל מעשנים.\n");
                        count++;
                        richTextBox2.AppendText("להפסיק לעשן \n" + count2);
                        count2++;
                    }
                    if (37 > patient1.HCT)
                    {
                        richTextBox1.AppendText(count + ".קיים ערך נמוך של נפח כדוריות הדם האדומות אשר מצביע לרוב על דימום או על אנמיה.\n");
                        count++;
                        richTextBox2.AppendText("שני כדורי 10 מג של בי-12 ביום למשך חודש \n" + count2);
                        count2++;
                        richTextBox2.AppendText("להתפנות בדחיפות לבית חולים \n" + count2);
                        count2++;
                    }
                }
                else
                {
                    if (47 < patient1.HCT)
                    {
                        richTextBox1.AppendText(count + ".קיים ערך גבוה של נפח כדוריות הדם האדומות  דבר זה שכיח בדרך כלל אצל מעשנים.\n");
                        count++;
                        richTextBox2.AppendText("להפסיק לעשן \n" + count2);
                        count2++;
                    }
                    if (33 > patient1.HCT)
                    {
                        richTextBox1.AppendText(count + ".קיים ערך נמוך של נפח כדוריות הדם האדומות אשר מצביע לרוב על דימום או על אנמיה.\n");
                        count++;
                        richTextBox2.AppendText("שני כדורי 10 מג של בי-12 ביום למשך חודש \n" + count2);
                        count2++;
                        richTextBox2.AppendText("להתפנות בדחיפות לבית חולים \n" + count2);
                        count2++;
                    }
                }
            }
            if (43 < patient1.Urea)
            {
                if(patient1.origin == 2 && 47.3 < patient1.Urea)
                {
                    richTextBox1.AppendText(count + ".קיים ערך גבוה של רמת השתנן בדם אשר עלולים להצביע על מחלות כליה, התייבשות או דיאטה עתירת חלבונים.\n");
                    count++;
                    richTextBox2.AppendText("לתאם פגישה עם תזונאי \n" + count2);
                    count2++;
                    richTextBox2.AppendText("הפניה לאבחנה ספציפית לצורך קביעת טיפול \n" + count2);
                    count2++;
                }
                else
                {
                    richTextBox1.AppendText(count + ".קיים ערך גבוה של רמת השתנן בדם אשר עלולים להצביע על מחלות כליה, התייבשות או דיאטה עתירת חלבונים.\n");
                    count++;
                    richTextBox2.AppendText("לתאם פגישה עם תזונאי \n" + count2);
                    count2++;
                    richTextBox2.AppendText("הפניה לאבחנה ספציפית לצורך קביעת טיפול \n" + count2);
                    count2++;
                }

            }
            if (17 > patient1.Urea)
            {
                if (patient1.origin == 2 && 38.7 > patient1.Urea)
                {
                    richTextBox1.AppendText(count + ".קיים ערך נמוך של רמת השתנן בדם אשר מצביעים על  תת תזונה, דיאטה דלת חלבון או מחלת כבד. יש לציין שבהריון רמת השתנן יורדת.\n");
                    count++;
                    richTextBox2.AppendText("לתאם פגישה עם תזונאי \n" + count2);
                    count2++;
                    richTextBox2.AppendText("הפניה לאבחנה ספציפית לצורך קביעת טיפול \n" + count2);
                    count2++;
                }
                else
                {
                    richTextBox1.AppendText(count + ".קיים ערך נמוך של רמת השתנן בדם אשר מצביעים על  תת תזונה, דיאטה דלת חלבון או מחלת כבד. יש לציין שבהריון רמת השתנן יורדת.\n");
                    count++;
                    richTextBox2.AppendText("לתאם פגישה עם תזונאי \n" + count2);
                    count2++;
                    richTextBox2.AppendText("הפניה לאבחנה ספציפית לצורך קביעת טיפול \n" + count2);
                    count2++;
                }
            }
            if (15.5 < patient1.Hb)
            {
                richTextBox1.AppendText(count + ".קיים ערך גבוה של מוגלובין ערכים גבוהים מהנורמה יכולים להצביע על ריבוי של תאי דם אדומים (פוליציטמיה). המצב הזה שכיח בדרך כלל אצל מעשנים ואצל חולים במחלות־ריאה או במחלות של מוח־העצם.  .\n");
                count++;
            }
            if (11.5 > patient1.Hb)
            {
                richTextBox1.AppendText(count + ".קיים ערך נמוך של מוגלובין אשר מעידים על אנמיה.זו יכולה לנבוע מהפרעה המטולוגית, ממחסור בברזל ומדימומים.\n");
                count++;
                richTextBox2.AppendText("שני כדורי 10 מג של בי-12 ביום למשך חודש \n" + count2);
                count2++;
                richTextBox2.AppendText("להתפנות בדחיפות לבית חולים \n" + count2);
                count2++;
                richTextBox2.AppendText("זריקה של הורמון לעידוד ייצור תאי הדם האדומים \n" + count2);
                count2++;
            }
            if (0.5 < patient1.Crtn)
            {
                richTextBox1.AppendText(count + ". קיים ערך גבוה של קריטאינין ערכים גבוהים מהנורמה עלולים להצביע על בעיה כלייתית ובמקרים חמורים על אי ספיקת כליות. ערכים גבוהים ניתן למצוא גם בעת שלשולים והקאות (הגורמים לפירוק מוגבר של שריר ולערכים גבוהים של קריאטינין), מחלות שריר וצריכה מוגברת של בשר.\n");
                count++;
                richTextBox2.AppendText("שני כדורי 5 מג של כורכום כי-3 של אלטמן ביום למשך חודש \n" + count2);
                count2++;
                richTextBox2.AppendText("לתאם פגישה עם תזונאית \n" + count2);
                count2++;
            }
            if (0.2 > patient1.Crtn)
            {
                richTextBox1.AppendText(count + ".קיים ערך נמוך של קריטאינין אשר נראים לרוב בחולים בעלי מסת שריר ירודה מאוד ואנשים בתת תזונה שאינם צורכים די חלבון.\n");
                count++;
                richTextBox2.AppendText("לתאם פגישה עם תזונאית \n" + count2);
                count2++;
            }
            if (patient1.sex == "man")
            {
                if (160 < patient1.Iron)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של ברזל ערכים גבוהים עלולים להצביע על הרעלת ברזל. \n");
                    count++;
                    richTextBox2.AppendText(" להתפנות לבית חולים \n" + count2);
                    count2++;
                }
                if (60 > patient1.Iron)
                {
                    richTextBox1.AppendText(count + ". קיים ערך נמוך של ברזל אשר מעיד בדרך כלל על תזונה לא מספקת או על עלייה בצורך בברזל (למשל בהריון) או על איבוד דם בעקבות דימום. \n");
                    count++;
                    richTextBox2.AppendText(" להתפנות לבית חולים \n" + count2);
                    count2++;
                    richTextBox2.AppendText("שני כדורי 10 מג של בי-12 ביום למשך חודש \n" + count2);
                    count2++;
                }
            }
            else
            {
                if (96 < patient1.Iron)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של ברזל ערכים גבוהים עלולים להצביע על הרעלת ברזל. \n");
                    count++;
                    richTextBox2.AppendText(" להתפנות לבית חולים \n" + count2);
                    count2++;
                }
                if (48 > patient1.Iron)
                {
                    richTextBox1.AppendText(count + ". קיים ערך נמוך של ברזל אשר מעיד בדרך כלל על תזונה לא מספקת או על עלייה בצורך בברזל (למשל בהריון) או על איבוד דם בעקבות דימום. \n");
                    count++;
                    richTextBox2.AppendText(" להתפנות לבית חולים \n" + count2);
                    count2++;
                    richTextBox2.AppendText("שני כדורי 10 מג של בי-12 ביום למשך חודש \n" + count2);
                    count2++;
                }
            }
            if (patient1.sex == "man")
            {
                if (62 < patient1.HDL)
                {
                    if (patient1.origin == 0 && 74.4 < patient1.HDL)
                    {
                        richTextBox1.AppendText(count + ". קיים ערך גבוה של 'הכולסטרול הטוב', הינו מולקולה דמוית חלבון ערכים גבוהים : לרוב אינן מזיקות. פעילות גופנית מעלה את רמות הכולסטרול הטוב. \n");
                        count++;
                    }
                    else
                    {
                        richTextBox1.AppendText(count + ". קיים ערך גבוה של 'הכולסטרול הטוב', הינו מולקולה דמוית חלבון ערכים גבוהים : לרוב אינן מזיקות. פעילות גופנית מעלה את רמות הכולסטרול הטוב. \n");
                        count++;
                    }
                }
                if (29 > patient1.HDL)
                {
                    if (patient1.origin == 0 && 23.2 > patient1.HDL)
                    {
                        richTextBox1.AppendText(count + ". קיים ערך נמוך של 'הכולסטרול הטוב', הינו מולקולה דמוית חלבון ערכים נמוכים עשויים להצביע על סיכון למחלות לב, על היפרליפידמיה )יתר שומנים בדם( או על סוכרת מבוגרים . \n");
                        count++;
                    }
                    else
                    {
                        richTextBox1.AppendText(count + ". קיים ערך נמוך של 'הכולסטרול הטוב', הינו מולקולה דמוית חלבון ערכים נמוכים עשויים להצביע על סיכון למחלות לב, על היפרליפידמיה )יתר שומנים בדם( או על סוכרת מבוגרים . \n");
                        count++;
                        richTextBox2.AppendText(" לתאם פגישה עם תזונאי, כדור 5 מג של סימוביל ביום למשך שבוע \n" + count2);
                        count2++;
                        richTextBox2.AppendText(" התאמת אינסולין למטופל \n" + count2);
                        count2++;
                    }
                }
            }
            else
            {
                if (82 < patient1.HDL)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של 'הכולסטרול הטוב', הינו מולקולה דמוית חלבון ערכים גבוהים : לרוב אינן מזיקות. פעילות גופנית מעלה את רמות הכולסטרול הטוב. \n");
                    count++;
                }
                if (34 > patient1.HDL)
                {
                    richTextBox1.AppendText(count + ". קיים ערך נמוך של 'הכולסטרול הטוב', הינו מולקולה דמוית חלבון ערכים נמוכים עשויים להצביע על סיכון למחלות לב, על היפרליפידמיה )יתר שומנים בדם( או על סוכרת מבוגרים . \n");
                    count++;
                    richTextBox2.AppendText(" לתאם פגישה עם תזונאי, כדור 5 מג של סימוביל ביום למשך שבוע \n" + count2);
                    count2++;
                    richTextBox2.AppendText(" התאמת אינסולין למטופל \n" + count2);
                    count2++;    
                }
            }
            if (patient1.origin == 2)
            {
                if (120 < patient1.AP)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של פוסםטזה אלקלית עלול להצביע על מחלות כבד, מחלות בדרכי המרה, הריון, פעילות יתר של בלוטת התריס או שימוש בתרופות שונות. \n");
                    count++;
                    richTextBox2.AppendText(" הפניה לטיופל חירוגי \n" + count2);
                    count2++;
                    richTextBox2.AppendText(" הפניה לרופא המשפחה לצורך התאמה בין התרופות \n" + count2);
                    count2++;
                    richTextBox2.AppendText(" Propylthiouracil להקטנת פעילות בלוטת התריס \n" + count2);
                    count2++;
                }
                if (60 > patient1.AP)
                {
                    richTextBox1.AppendText(count + ". ויטמין B6 חומצה פולית. ,B12ויטמין ,C  קיים ערך נמוך של פוסםטזה אלקלית עלול להצביע על על תזונה לקויה שחסרים בה חלבונים. חוסר בוויטמינים כמו ויטמין . \n");
                    count++;
                    richTextBox2.AppendText(" הפניה לבדיקת דם לזיהוי הויטמינים החסרים  \n" + count2);
                    count2++;
                }
            }
            else
            {
                if (90 < patient1.AP)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של פוסםטזה אלקלית עלול להצביע על מחלות כבד, מחלות בדרכי המרה, הריון, פעילות יתר של בלוטת התריס או שימוש בתרופות שונות. \n");
                    count++;
                    richTextBox2.AppendText(" הפניה לטיופל חירוגי \n" + count2);
                    count2++;
                    richTextBox2.AppendText(" הפניה לרופא המשפחה לצורך התאמה בין התרופות \n" + count2);
                    count2++;
                    richTextBox2.AppendText(" Propylthiouracil להקטנת פעילות בלוטת התריס \n" + count2);
                    count2++;
                }
                if (30 > patient1.AP)
                {
                    richTextBox1.AppendText(count + ". ויטמין B6 חומצה פולית. ,B12ויטמין ,C  קיים ערך נמוך של פוסםטזה אלקלית עלול להצביע על על תזונה לקויה שחסרים בה חלבונים. חוסר בוויטמינים כמו ויטמין . \n");
                    count++;
                    richTextBox2.AppendText(" הפניה לבדיקת דם לזיהוי הויטמינים החסרים  \n" + count2);
                    count2++;
                }
            }
            patient1.setdi(richTextBox1.Text);
            patient1.setse(richTextBox2.Text);
        }
        public void ClearAll()
        {
            //textBox1.Clear;
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void NeutBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void LymphBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void RBCBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void HCTBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void UreaBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void HbBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void CrtnBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void IronBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        public void Clearpatient()
        {
            textBox1.Text = string.Empty; textBox2.Text = string.Empty; textBox3.Text = string.Empty; textBox4.Text = string.Empty;
            checkBox1.Checked = false; checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false; textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
            comboBox1.Text = string.Empty; checkBox8.Checked = false;
            chart1.Titles.Clear();
            richTextBox1.Clear();
            richTextBox2.Clear();
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            patient1 = null;
            Clearpatient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1_place = new Form1();
            this.Hide();
            form1_place.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (patient1 == null)
            {
                MessageBox.Show("You need to add patient first");
                return;
            }

            string file = ""; //variable for the Excel File Location
            DataTable dt = new DataTable(); //container for our excel data
            DataRow row;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.

            if (result == DialogResult.OK) // Check if Result == "OK".
            {
                file = openFileDialog1.FileName; //get the filename with the location of the file
                try
                {
                    //Create Object for Microsoft.Office.Interop.Excel that will be use to read excel file

                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

                    Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(file);

                    Microsoft.Office.Interop.Excel._Worksheet excelWorksheet = excelWorkbook.Sheets[1];

                    Microsoft.Office.Interop.Excel.Range excelRange = excelWorksheet.UsedRange;

                    int rowCount = excelRange.Rows.Count; //get row count of excel data

                    int colCount = excelRange.Columns.Count; // get column count of excel data

                    //Get the first Column of excel file which is the Column Name

                    for (int i = 1; i <= rowCount; i++)
                    {
                        for (int j = 1; j <= colCount; j++)
                        {
                            dt.Columns.Add(excelRange.Cells[i, j].Value2.ToString());

                        }
                        break;
                    }

                    //Get Row Data of Excel

                    int rowCounter; //This variable is used for row index number
                    for (int i = 2; i <= rowCount; i++) //Loop for available row of excel data
                    {
                        row = dt.NewRow(); //assign new row to DataTable
                        rowCounter = 0;
                        for (int j = 1; j <= colCount; j++) //Loop for available column of excel data
                        {
                            //check if cell is empty
                            if (excelRange.Cells[i, j] != null && excelRange.Cells[i, j].Value2 != null)
                            {
                                row[rowCounter] = excelRange.Cells[i, j].Value2.ToString();
                            }
                            else
                            {
                                row[i] = "";
                            }
                            rowCounter++;
                        }
                        dt.Rows.Add(row); //add row to DataTable
                    }

                    float WBC = 0;
                    float Neut = 0;
                    float Lymph = 0;
                    float RBC = 0;
                    float HCT = 0;
                    float Urea = 0;
                    float Hb = 0;
                    float Crtn = 0;
                    float Iron = 0;
                    float HDL = 0;
                    float AP = 0;

                    foreach (DataRow dr in dt.Rows)
                    {
                    
                        WBC = float.Parse(dr["WBC"].ToString());
                        Neut = float.Parse(dr["Neut"].ToString());
                        Lymph = float.Parse(dr["Lymph"].ToString());
                        RBC = float.Parse(dr["RBC"].ToString());
                        HCT = float.Parse(dr["HCT"].ToString());
                        Urea = float.Parse(dr["Urea"].ToString());
                        Hb = float.Parse(dr["Hb"].ToString());
                        Crtn = float.Parse(dr["Crtn"].ToString());
                        Iron = float.Parse(dr["Iron"].ToString());
                        HDL = float.Parse(dr["HDL"].ToString());
                        AP = float.Parse(dr["AP"].ToString());
                    }


                    patient1.setBloodTest(WBC, Neut, Lymph, RBC, HCT, Urea, Hb, Crtn, Iron, HDL, AP);
                    //close and clean excel process
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    Marshal.ReleaseComObject(excelRange);
                    Marshal.ReleaseComObject(excelWorksheet);
                    //quit apps
                    excelWorkbook.Close();
                    Marshal.ReleaseComObject(excelWorkbook);
                    excelApp.Quit();
                    Marshal.ReleaseComObject(excelApp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    
}
