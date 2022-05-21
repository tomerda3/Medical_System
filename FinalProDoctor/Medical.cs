using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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


            string sex;
            if (checkBox1.Checked)
                sex = "male";
            else sex = "female";

            try
            {
                int orindex = comboBox1.SelectedIndex;
                patient1 = new Patient(textBox1.Text, Int32.Parse(textBox2.Text), sex, checkBox1.Checked, Int32.Parse(textBox3.Text), Int32.Parse(textBox4.Text), orindex);
            }

            catch (FormatException e1)
            {
                textBox5.Text = "There is a problem in the input data";
                return;
            }
           
        }

        private void WBCBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            textBox5.Text = "";


            /*          float WBC = 0;
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

                        try
                        {
                            // if
                            // input blood test from excel.

                            // else
                            // input blood test from user.
                            WBC = float.Parse(WBCBox.Text);
                            Neut = float.Parse(NeutBox.Text);
                            Lymph = float.Parse(LymphBox.Text);
                            RBC = float.Parse(RBCBox.Text);
                            HCT = float.Parse(HCTBox.Text);
                            Urea = float.Parse(UreaBox.Text);
                            Hb = float.Parse(HbBox.Text);
                            Crtn = float.Parse(CrtnBox.Text);
                            Iron = float.Parse(IronBox.Text);
                            HDL = float.Parse(HDLBox.Text);
                            AP = float.Parse(APBox.Text);

                        }

                        catch (FormatException e1)
                        {
                            textBox5.Text = "There is a problem in the input data";
                        }

                        if (patient1 == null)
                        {
                            MessageBox.Show("There is not patient");
                            return;
                        }
                        if (patient1 != null)
                            patient1.setBloodTest(WBC, Neut, Lymph, RBC, HCT, Urea, Hb, Crtn, Iron, HDL, AP);*/

            if (patient1 == null)
            {
                MessageBox.Show("You need to add patient first");
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
            richTextBox1.AppendText(" : שם המטופל " + patient1.name);
            richTextBox1.AppendText("\n : אבחון המטופל\n");
            richTextBox1.AppendText("\n -------- patient1 HDL:" + patient1.HDL);

            if (patient1.age >= 18)
                analysisForAdult();
            if (patient1.age < 18 && patient1.age > 3)
                analysisForChildren();
            if (patient1.age <= 3)
                analysisForbaby();
        }
        public void setBlood(float WBC, float Neut, float Lymph, float RBC, float HCT, float Urea, float Hb, float Crtn, float Iron, float HDL, float AP)
        {
            patient1.setBloodTest(WBC, Neut, Lymph, RBC, HCT, Urea, Hb, Crtn, Iron, HDL, AP);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            BloodTest start = new BloodTest();
            // this.Hide();
            start.Show();
            ///  this.Close();
        }
        public void analysisForAdult()
        {
            int count = 1;
            if (11000 < patient1.WBC)
            {
                richTextBox1.AppendText(count + ".ערך גבוה של כדורי דם לבנים יכולות להצביע על קיומו של זיהום, אם קיימת מחלת חום. במקרים אחרים, נדירים ביותר, עלולים ערכים גבוהים מאוד להעיד על מחלת דם או סרטן\n");
                count++;
            }
            if (4500 > patient1.WBC)
            {
                richTextBox1.AppendText(count + ". קיים ערך נמוך של כדורי דם לבנים היכול להצביע על מחלה ויראלית, כשל של מערכת החיסון ובמקרים נדירים ביותר על סרטן\n");
                count++;
            }

            if (54 < patient1.Neut)
            {
                richTextBox1.AppendText(count + ".ערך גבוה של נויטרופיל מעידים לרוב על זיהום חיידקי.\n");
                count++;
            }

            if (28 < patient1.Neut)
            {
                richTextBox1.AppendText(count + ".ערך נמוך של נויטרופיל מעידים על הפרעה ביצירת הדם, על נטייה לזיהומים מחיידקים ובמקרים נדירים - על תהליך סרטני.\n");
                count++;
            }
            
            if (52 < patient1.Lymph)
            {
                richTextBox1.AppendText(count + ".ערך גבוה של לימפוציטים עשויים להצביע על זיהום חיידקי ממושך או על סרטן הלימפומה.\n");
                count++;
            }

            if (36 < patient1.Lymph)
            {
                richTextBox1.AppendText(count + ".ערך נמוך של לימפוציטים מעידים על בעיה ביצירת תאי הדם.\n");
                count++;
            }
            if (6 < patient1.RBC)
            {
                richTextBox1.AppendText(count + ".קיים ערך גבוה של כדוריות הדם האדומות אחראיות על קשירת חמצן מהריאות עלולים להצביע על הפרעה במערכת ייצור הדם. רמות גבוהות נצפו גם אצל מעשנים ואצל חולים במחלת ריאות.\n");
                count++;
            }

            if (4.5 < patient1.RBC)
            {
                richTextBox1.AppendText(count + ".קיים ערך נמוך של כדוריות הדם האדומות אחראיות על קשירת חמצן מהריאות העלולים להצביע על אנמיה או על דימומים קשים.\n");
                count++;
            }
            if (6 < patient1.HCT || 4 > patient1.HCT)
            {
                if (patient1.sex == "male")
                {
                    if (54 < patient1.HCT)
                    {
                        richTextBox1.AppendText(count + ".קיים ערך גבוה של נפח כדוריות הדם האדומות  דבר זה שכיח בדרך כלל אצל מעשנים.\n");
                        count++;
                    }
                    if (37 > patient1.HCT)
                    {
                        richTextBox1.AppendText(count + ".קיים ערך נמוך של נפח כדוריות הדם האדומות אשר מצביע לרוב על דימום או על אנמיה.\n");
                        count++;
                    }
                }
                else
                {
                    if (47 < patient1.HCT)
                    {
                        richTextBox1.AppendText(count + ".קיים ערך גבוה של נפח כדוריות הדם האדומות  דבר זה שכיח בדרך כלל אצל מעשנים.\n");
                        count++;
                    }
                    if (33 > patient1.HCT)
                    {
                        richTextBox1.AppendText(count + ".קיים ערך נמוך של נפח כדוריות הדם האדומות אשר מצביע לרוב על דימום או על אנמיה.\n");
                        count++;
                    }
                }
            }

            if (43 < patient1.Urea)
            {
                if (patient1.origin == 2 && 47.3 < patient1.Urea)
                {
                    richTextBox1.AppendText(count + ".קיים ערך גבוה של רמת השתנן בדם אשר עלולים להצביע על מחלות כליה, התייבשות או דיאטה עתירת חלבונים.\n");
                    count++;
                }
                else
                {
                    richTextBox1.AppendText(count + ".קיים ערך גבוה של רמת השתנן בדם אשר עלולים להצביע על מחלות כליה, התייבשות או דיאטה עתירת חלבונים.\n");
                    count++;
                }

            }
            if (17 > patient1.Urea)
            {
                if (patient1.origin == 2 && 38.7 > patient1.Urea)
                {
                    richTextBox1.AppendText(count + ".קיים ערך נמוך של רמת השתנן בדם אשר מצביעים על  תת תזונה, דיאטה דלת חלבון או מחלת כבד. יש לציין שבהריון רמת השתנן יורדת.\n");
                    count++;
                }
                else
                {
                    richTextBox1.AppendText(count + ".קיים ערך נמוך של רמת השתנן בדם אשר מצביעים על  תת תזונה, דיאטה דלת חלבון או מחלת כבד. יש לציין שבהריון רמת השתנן יורדת.\n");
                    count++;
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
                }
            }

            if(patient1.age > 59)
            {
                if (1.2 < patient1.Crtn)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של קריטאינין ערכים גבוהים מהנורמה עלולים להצביע על בעיה כלייתית ובמקרים חמורים על אי ספיקת כליות. ערכים גבוהים ניתן למצוא גם בעת שלשולים והקאות (הגורמים לפירוק מוגבר של שריר ולערכים גבוהים של קריאטינין), מחלות שריר וצריכה מוגברת של בשר.\n");
                    count++;
                }
                if (0.6 > patient1.Crtn)
                {
                    richTextBox1.AppendText(count + ".קיים ערך נמוך של קריטאינין אשר נראים לרוב בחולים בעלי מסת שריר ירודה מאוד ואנשים בתת תזונה שאינם צורכים די חלבון.\n");
                    count++;
                }
            }
            else
            {
                if (0.6 < patient1.Crtn)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של קריטאינין ערכים גבוהים מהנורמה עלולים להצביע על בעיה כלייתית ובמקרים חמורים על אי ספיקת כליות. ערכים גבוהים ניתן למצוא גם בעת שלשולים והקאות (הגורמים לפירוק מוגבר של שריר ולערכים גבוהים של קריאטינין), מחלות שריר וצריכה מוגברת של בשר.\n");
                    count++;
                }
                if (1 > patient1.Crtn)
                {
                    richTextBox1.AppendText(count + ".קיים ערך נמוך של קריטאינין אשר נראים לרוב בחולים בעלי מסת שריר ירודה מאוד ואנשים בתת תזונה שאינם צורכים די חלבון.\n");
                    count++;
                }
            }

            if (patient1.sex == "man")
            {
                if (60 < patient1.Iron)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של ברזל ערכים גבוהים עלולים להצביע על הרעלת ברזל. \n");
                    count++;
                }
                if (160 > patient1.Iron)
                {
                    richTextBox1.AppendText(count + ". קיים ערך נמוך של ברזל אשר מעיד בדרך כלל על תזונה לא מספקת או על עלייה בצורך בברזל (למשל בהריון) או על איבוד דם בעקבות דימום. \n");
                    count++;
                }
            }
            else
            {
                if (96 < patient1.Iron)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של ברזל ערכים גבוהים עלולים להצביע על הרעלת ברזל. \n");
                    count++;
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
                }
            }
            if (patient1.origin == 2)
            {
                if (120 < patient1.AP)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של פוסםטזה אלקלית עלול להצביע על מחלות כבד, מחלות בדרכי המרה, הריון, פעילות יתר של בלוטת התריס או שימוש בתרופות שונות. \n");
                    count++;
                }
                if (60 > patient1.AP)
                {
                    richTextBox1.AppendText(count + ". ויטמין B6 חומצה פולית. ,B12ויטמין ,C  קיים ערך נמוך של פוסםטזה אלקלית עלול להצביע על על תזונה לקויה שחסרים בה חלבונים. חוסר בוויטמינים כמו ויטמין . \n");
                    count++;
                }
            }
            else
            {
                if (90 < patient1.AP)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של פוסםטזה אלקלית עלול להצביע על מחלות כבד, מחלות בדרכי המרה, הריון, פעילות יתר של בלוטת התריס או שימוש בתרופות שונות. \n");
                    count++;
                }
                if (30 > patient1.AP)
                {
                    richTextBox1.AppendText(count + ". ויטמין B6 חומצה פולית. ,B12ויטמין ,C  קיים ערך נמוך של פוסםטזה אלקלית עלול להצביע על על תזונה לקויה שחסרים בה חלבונים. חוסר בוויטמינים כמו ויטמין . \n");
                    count++;
                }
            }
        }
        public void analysisForChildren()
        {
            int count = 1;
            if (15500 > patient1.WBC)
            {
                richTextBox1.AppendText(count + ".ות על קיומו של זיהום, אם קיימת מחלת חום. במקרים אחרים, נדירים ביותר, עלולים ערכים גבוהים מאוד להעיד על מחלת דם או סרטן\n");
                count++;
            }
            if (5500 < patient1.WBC)
            {
                richTextBox1.AppendText(count + ". קיים ערך נמוך של כדורי דם לבנים היכול להצביע על מחלה ויראלית, כשל של מערכת החיסון ובמקרים נדירים ביותר על סרטן\n");
                count++;
            }

            if (54 < patient1.Neut)
            {
                richTextBox1.AppendText(count + ".ערך גבוה של נויטרופיל מעידים לרוב על זיהום חיידקי.\n");
                count++;
            }

            if (28 < patient1.Neut)
            {
                richTextBox1.AppendText(count + ".ערך נמוך של נויטרופיל מעידים על הפרעה ביצירת הדם, על נטייה לזיהומים מחיידקים ובמקרים נדירים - על תהליך סרטני.\n");
                count++;
            }

            if (52 < patient1.Lymph)
            {
                richTextBox1.AppendText(count + ".ערך גבוה של לימפוציטים עשויים להצביע על זיהום חיידקי ממושך או על סרטן הלימפומה.\n");
                count++;
            }

            if (36 < patient1.Lymph)
            {
                richTextBox1.AppendText(count + ".ערך נמוך של לימפוציטים מעידים על בעיה ביצירת תאי הדם.\n");
                count++;
            }
            if (6 < patient1.RBC)
            {
                richTextBox1.AppendText(count + ".קיים ערך גבוה של כדוריות הדם האדומות אחראיות על קשירת חמצן מהריאות עלולים להצביע על הפרעה במערכת ייצור הדם. רמות גבוהות נצפו גם אצל מעשנים ואצל חולים במחלת ריאות.\n");
                count++;
            }

            if (4.5 < patient1.RBC)
            {
                richTextBox1.AppendText(count + ".קיים ערך נמוך של כדוריות הדם האדומות אחראיות על קשירת חמצן מהריאות העלולים להצביע על אנמיה או על דימומים קשים.\n");
                count++;
            }
            if (6 < patient1.HCT || 4 > patient1.HCT)
            {
                if (patient1.sex == "male")
                {
                    if (54 < patient1.HCT)
                    {
                        richTextBox1.AppendText(count + ".קיים ערך גבוה של נפח כדוריות הדם האדומות  דבר זה שכיח בדרך כלל אצל מעשנים.\n");
                        count++;
                    }
                    if (37 > patient1.HCT)
                    {
                        richTextBox1.AppendText(count + ".קיים ערך נמוך של נפח כדוריות הדם האדומות אשר מצביע לרוב על דימום או על אנמיה.\n");
                        count++;
                    }
                }
                else
                {
                    if (47 < patient1.HCT)
                    {
                        richTextBox1.AppendText(count + ".קיים ערך גבוה של נפח כדוריות הדם האדומות  דבר זה שכיח בדרך כלל אצל מעשנים.\n");
                        count++;
                    }
                    if (33 > patient1.HCT)
                    {
                        richTextBox1.AppendText(count + ".קיים ערך נמוך של נפח כדוריות הדם האדומות אשר מצביע לרוב על דימום או על אנמיה.\n");
                        count++;
                    }
                }
            }
            if (43 < patient1.Urea)
            {
                if (patient1.origin == 2 && 47.3 < patient1.Urea)
                {
                    richTextBox1.AppendText(count + ".קיים ערך גבוה של רמת השתנן בדם אשר עלולים להצביע על מחלות כליה, התייבשות או דיאטה עתירת חלבונים.\n");
                    count++;
                }
                else
                {
                    richTextBox1.AppendText(count + ".קיים ערך גבוה של רמת השתנן בדם אשר עלולים להצביע על מחלות כליה, התייבשות או דיאטה עתירת חלבונים.\n");
                    count++;
                }

            }
            if (17 > patient1.Urea)
            {
                if (patient1.origin == 2 && 38.7 > patient1.Urea)
                {
                    richTextBox1.AppendText(count + ".קיים ערך נמוך של רמת השתנן בדם אשר מצביעים על  תת תזונה, דיאטה דלת חלבון או מחלת כבד. יש לציין שבהריון רמת השתנן יורדת.\n");
                    count++;
                }
                else
                {
                    richTextBox1.AppendText(count + ".קיים ערך נמוך של רמת השתנן בדם אשר מצביעים על  תת תזונה, דיאטה דלת חלבון או מחלת כבד. יש לציין שבהריון רמת השתנן יורדת.\n");
                    count++;
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
            }
            if (1 < patient1.Crtn)
            {
                richTextBox1.AppendText(count + ". קיים ערך גבוה של קריטאינין ערכים גבוהים מהנורמה עלולים להצביע על בעיה כלייתית ובמקרים חמורים על אי ספיקת כליות. ערכים גבוהים ניתן למצוא גם בעת שלשולים והקאות (הגורמים לפירוק מוגבר של שריר ולערכים גבוהים של קריאטינין), מחלות שריר וצריכה מוגברת של בשר.\n");
                count++;
            }
            if (0.5 > patient1.Crtn)
            {
                richTextBox1.AppendText(count + ".קיים ערך נמוך של קריטאינין אשר נראים לרוב בחולים בעלי מסת שריר ירודה מאוד ואנשים בתת תזונה שאינם צורכים די חלבון.\n");
                count++;
            }
            if (patient1.sex == "man")
            {
                if (160 < patient1.Iron)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של ברזל ערכים גבוהים עלולים להצביע על הרעלת ברזל. \n");
                    count++;
                }
                if (60 > patient1.Iron)
                {
                    richTextBox1.AppendText(count + ". קיים ערך נמוך של ברזל אשר מעיד בדרך כלל על תזונה לא מספקת או על עלייה בצורך בברזל (למשל בהריון) או על איבוד דם בעקבות דימום. \n");
                    count++;
                }
            }
            else
            {
                if (96 < patient1.Iron)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של ברזל ערכים גבוהים עלולים להצביע על הרעלת ברזל. \n");
                    count++;
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
                }
            }
            if (patient1.origin == 2)
            {
                if (120 < patient1.AP)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של פוסםטזה אלקלית עלול להצביע על מחלות כבד, מחלות בדרכי המרה, הריון, פעילות יתר של בלוטת התריס או שימוש בתרופות שונות. \n");
                    count++;
                }
                if (60 > patient1.AP)
                {
                    richTextBox1.AppendText(count + ". ויטמין B6 חומצה פולית. ,B12ויטמין ,C  קיים ערך נמוך של פוסםטזה אלקלית עלול להצביע על על תזונה לקויה שחסרים בה חלבונים. חוסר בוויטמינים כמו ויטמין . \n");
                    count++;
                }
            }
            else
            {
                if (90 < patient1.AP)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של פוסםטזה אלקלית עלול להצביע על מחלות כבד, מחלות בדרכי המרה, הריון, פעילות יתר של בלוטת התריס או שימוש בתרופות שונות. \n");
                    count++;
                }
                if (30 > patient1.AP)
                {
                    richTextBox1.AppendText(count + ". ויטמין B6 חומצה פולית. ,B12ויטמין ,C  קיים ערך נמוך של פוסםטזה אלקלית עלול להצביע על על תזונה לקויה שחסרים בה חלבונים. חוסר בוויטמינים כמו ויטמין . \n");
                    count++;
                }
            }
        }
        public void analysisForbaby()
        {
            int count = 1;
            if (17500 > patient1.WBC)
            {
                richTextBox1.AppendText(count + ".ות על קיומו של זיהום, אם קיימת מחלת חום. במקרים אחרים, נדירים ביותר, עלולים ערכים גבוהים מאוד להעיד על מחלת דם או סרטן\n");
                count++;
            }
            if (6000 < patient1.WBC)
            {
                richTextBox1.AppendText(count + ". קיים ערך נמוך של כדורי דם לבנים היכול להצביע על מחלה ויראלית, כשל של מערכת החיסון ובמקרים נדירים ביותר על סרטן\n");
                count++;
            }

            if (54 < patient1.Neut)
            {
                richTextBox1.AppendText(count + ".ערך גבוה של נויטרופיל מעידים לרוב על זיהום חיידקי.\n");
                count++;
            }

            if (28 < patient1.Neut)
            {
                richTextBox1.AppendText(count + ".ערך נמוך של נויטרופיל מעידים על הפרעה ביצירת הדם, על נטייה לזיהומים מחיידקים ובמקרים נדירים - על תהליך סרטני.\n");
                count++;
            }

            if (52 < patient1.Lymph)
            {
                richTextBox1.AppendText(count + ".ערך גבוה של לימפוציטים עשויים להצביע על זיהום חיידקי ממושך או על סרטן הלימפומה.\n");
                count++;
            }

            if (36 < patient1.Lymph)
            {

            }
            if (6 < patient1.RBC)
            {
                richTextBox1.AppendText(count + ".קיים ערך גבוה של כדוריות הדם האדומות אחראיות על קשירת חמצן מהריאות עלולים להצביע על הפרעה במערכת ייצור הדם. רמות גבוהות נצפו גם אצל מעשנים ואצל חולים במחלת ריאות.\n");
                count++;
            }

            if (4.5 < patient1.RBC)
            {
                richTextBox1.AppendText(count + ".קיים ערך נמוך של כדוריות הדם האדומות אחראיות על קשירת חמצן מהריאות העלולים להצביע על אנמיה או על דימומים קשים.\n");
                count++;
            }
            if (6 < patient1.HCT || 4 > patient1.HCT)
            {
                if (patient1.sex == "male")
                {
                    if (54 < patient1.HCT)
                    {
                        richTextBox1.AppendText(count + ".קיים ערך גבוה של נפח כדוריות הדם האדומות  דבר זה שכיח בדרך כלל אצל מעשנים.\n");
                        count++;
                    }
                    if (37 > patient1.HCT)
                    {
                        richTextBox1.AppendText(count + ".קיים ערך נמוך של נפח כדוריות הדם האדומות אשר מצביע לרוב על דימום או על אנמיה.\n");
                        count++;
                    }
                }
                else
                {
                    if (47 < patient1.HCT)
                    {
                        richTextBox1.AppendText(count + ".קיים ערך גבוה של נפח כדוריות הדם האדומות  דבר זה שכיח בדרך כלל אצל מעשנים.\n");
                        count++;
                    }
                    if (33 > patient1.HCT)
                    {
                        richTextBox1.AppendText(count + ".קיים ערך נמוך של נפח כדוריות הדם האדומות אשר מצביע לרוב על דימום או על אנמיה.\n");
                        count++;
                    }
                }
            }
            if (43 < patient1.Urea)
            {
                if(patient1.origin == 2 && 47.3 < patient1.Urea)
                {
                    richTextBox1.AppendText(count + ".קיים ערך גבוה של רמת השתנן בדם אשר עלולים להצביע על מחלות כליה, התייבשות או דיאטה עתירת חלבונים.\n");
                    count++;
                }
                else
                {
                    richTextBox1.AppendText(count + ".קיים ערך גבוה של רמת השתנן בדם אשר עלולים להצביע על מחלות כליה, התייבשות או דיאטה עתירת חלבונים.\n");
                    count++;
                }

            }
            if (17 > patient1.Urea)
            {
                if (patient1.origin == 2 && 38.7 > patient1.Urea)
                {
                    richTextBox1.AppendText(count + ".קיים ערך נמוך של רמת השתנן בדם אשר מצביעים על  תת תזונה, דיאטה דלת חלבון או מחלת כבד. יש לציין שבהריון רמת השתנן יורדת.\n");
                    count++;
                }
                else
                {
                    richTextBox1.AppendText(count + ".קיים ערך נמוך של רמת השתנן בדם אשר מצביעים על  תת תזונה, דיאטה דלת חלבון או מחלת כבד. יש לציין שבהריון רמת השתנן יורדת.\n");
                    count++;
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
            }
            if (0.5 < patient1.Crtn)
            {
                richTextBox1.AppendText(count + ". קיים ערך גבוה של קריטאינין ערכים גבוהים מהנורמה עלולים להצביע על בעיה כלייתית ובמקרים חמורים על אי ספיקת כליות. ערכים גבוהים ניתן למצוא גם בעת שלשולים והקאות (הגורמים לפירוק מוגבר של שריר ולערכים גבוהים של קריאטינין), מחלות שריר וצריכה מוגברת של בשר.\n");
                count++;
            }
            if (0.2 > patient1.Crtn)
            {
                richTextBox1.AppendText(count + ".קיים ערך נמוך של קריטאינין אשר נראים לרוב בחולים בעלי מסת שריר ירודה מאוד ואנשים בתת תזונה שאינם צורכים די חלבון.\n");
                count++;
            }
            if (patient1.sex == "man")
            {
                if (60 < patient1.Iron)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של ברזל ערכים גבוהים עלולים להצביע על הרעלת ברזל. \n");
                    count++;
                }
                if (160 > patient1.Iron)
                {
                    richTextBox1.AppendText(count + ". קיים ערך נמוך של ברזל אשר מעיד בדרך כלל על תזונה לא מספקת או על עלייה בצורך בברזל (למשל בהריון) או על איבוד דם בעקבות דימום. \n");
                    count++;
                }
            }
            else
            {
                if (96 < patient1.Iron)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של ברזל ערכים גבוהים עלולים להצביע על הרעלת ברזל. \n");
                    count++;
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
                }
            }
            if (patient1.origin == 2)
            {
                if (120 < patient1.AP)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של פוסםטזה אלקלית עלול להצביע על מחלות כבד, מחלות בדרכי המרה, הריון, פעילות יתר של בלוטת התריס או שימוש בתרופות שונות. \n");
                    count++;
                }
                if (60 > patient1.AP)
                {
                    richTextBox1.AppendText(count + ". ויטמין B6 חומצה פולית. ,B12ויטמין ,C  קיים ערך נמוך של פוסםטזה אלקלית עלול להצביע על על תזונה לקויה שחסרים בה חלבונים. חוסר בוויטמינים כמו ויטמין . \n");
                    count++;
                }
            }
            else
            {
                if (90 < patient1.AP)
                {
                    richTextBox1.AppendText(count + ". קיים ערך גבוה של פוסםטזה אלקלית עלול להצביע על מחלות כבד, מחלות בדרכי המרה, הריון, פעילות יתר של בלוטת התריס או שימוש בתרופות שונות. \n");
                    count++;
                }
                if (30 > patient1.AP)
                {
                    richTextBox1.AppendText(count + ". ויטמין B6 חומצה פולית. ,B12ויטמין ,C  קיים ערך נמוך של פוסםטזה אלקלית עלול להצביע על על תזונה לקויה שחסרים בה חלבונים. חוסר בוויטמינים כמו ויטמין . \n");
                    count++;
                }
            }
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
            checkBox1.Checked = false; checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false;
            comboBox1.Text = string.Empty;
            chart1.Titles.Clear();
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
    }
    
}
