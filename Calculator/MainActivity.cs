using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;
using System;

namespace Calculator
{
    [Activity(Label = "Calc", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, plusbtn, minusbtn, timesbtn, dividebtn, equalbtn, clearbtn, backbtn, pointbtn;
        TextView expressionText;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            #region instation
            expressionText = FindViewById<TextView>(Resource.Id.expressionText);
            btn0 = FindViewById<Button>(Resource.Id.btn0);
            btn0.Click += Btn0_Click;
            btn1 = FindViewById<Button>(Resource.Id.btn1);
            btn1.Click += Btn1_Click;
            btn2 = FindViewById<Button>(Resource.Id.btn2);
            btn2.Click += Btn2_Click;
            btn3 = FindViewById<Button>(Resource.Id.btn3);
            btn3.Click += Btn3_Click;
            btn4 = FindViewById<Button>(Resource.Id.btn4);
            btn4.Click += Btn4_Click;
            btn5 = FindViewById<Button>(Resource.Id.btn5);
            btn5.Click += Btn5_Click;
            btn6 = FindViewById<Button>(Resource.Id.btn6);
            btn6.Click += Btn6_Click; 
            btn7 = FindViewById<Button>(Resource.Id.btn7);
            btn7.Click += Btn7_Click;
            btn8 = FindViewById<Button>(Resource.Id.btn8);
            btn8.Click += Btn8_Click;
            btn9 = FindViewById<Button>(Resource.Id.btn9);
            btn9.Click += Btn9_Click;
            plusbtn = FindViewById<Button>(Resource.Id.plusbtn);
            plusbtn.Click += Plusbtn_Click;
            minusbtn = FindViewById<Button>(Resource.Id.minusbtn);
            minusbtn.Click += Minusbtn_Click;
            timesbtn = FindViewById<Button>(Resource.Id.timesbtn);
            timesbtn.Click += Timesbtn_Click;
            dividebtn = FindViewById<Button>(Resource.Id.dividebtn);
            dividebtn.Click += Dividebtn_Click;
            equalbtn = FindViewById<Button>(Resource.Id.equalbtn);
            equalbtn.Click += Equalbtn_Click;
            clearbtn = FindViewById<Button>(Resource.Id.clearbtn);
            clearbtn.Click += Clearbtn_Click;
            backbtn = FindViewById<Button>(Resource.Id.backbtn);
            backbtn.Click += Backbtn_Click;
            pointbtn = FindViewById<Button>(Resource.Id.pointbtn);
            pointbtn.Click += Pointbtn_Click;
            #endregion
        }

        private void Pointbtn_Click(object sender, System.EventArgs e)
        {
            var toast = Toast.MakeText(this, ".", ToastLength.Short);
            toast.Show();
        }

        private void Backbtn_Click(object sender, System.EventArgs e)
        {
            if(expressionText.Text.Length > 0)
            {
                if (!(expressionText.Text.Contains("=")))
                {
                    if(expressionText.Text.Length == 1)
                    {
                        expressionText.Text = "0";
                    }
                    else { 
                        int textLength = expressionText.Text.Length;
                        expressionText.Text = expressionText.Text.Remove(textLength - 1, 1);
                    }
                }
            }
            else
            {
                expressionText.Text = "0";
            }
        }

        private void Clearbtn_Click(object sender, System.EventArgs e)
        {
            expressionText.Text = "0";
        }

        private void Equalbtn_Click(object sender, System.EventArgs e)
        {
            int textLength = expressionText.Text.Length;
            string lastChar = expressionText.Text.Substring(textLength - 1, 1);
            if (lastChar != "+" && lastChar != "-" && lastChar != "x" && lastChar != "÷")
            {
                string expression = expressionText.Text;
                ArrayList expList = new ArrayList();
                string temp = "";
                bool isOperator = false;
                float Result = 0;
                Operation operation = new Operation();
                operation.Parse(expression);
                double result = operation.Solve();
                expressionText.Text = result.ToString();
                //loop for getting the expression piecebypiece..
                //for (int i = 0; i < expression.Length; i++)
                //{
                //    string expSub = expression.Substring(i, 1);
                //    if (expSub == "+" || expSub == "-" || expSub == "x" || expSub == "÷")
                //    {
                //        expList.Add(temp);
                //        temp = "";
                //        isOperator = true;
                //    }
                //    else
                //    {
                //        temp += expSub;
                //    }

                //    if (isOperator)
                //    {
                //        temp += expSub;
                //        isOperator = false;
                //    }

                //    if((i+1) == expression.Length)
                //    {
                //        expList.Add(temp);
                //    }
                //}

                //ArrayList tempArr = new ArrayList();
                //ArrayList usedExpArr = new ArrayList();
                //for (int i = 0; i < expList.Count; i++)
                //{
                //     Convert.T

                //    for (int j = 0; j < length; j++)
                //    {

                //    }
                //    string z = expList[i].ToString();

                //    if (expList[i].Contains("+") || item.Contains("-") || item.Contains("x") || item.Contains("÷"))
                //    {

                //    }
                //    else
                //    {

                //    }
                //}

            }
        }

        private void Dividebtn_Click(object sender, System.EventArgs e)
        {
            //operationAppend("÷");
            operationAppend("/");
        }

        private void Timesbtn_Click(object sender, System.EventArgs e)
        {
            //operationAppend("x");
            operationAppend("*");
        }

        private void Minusbtn_Click(object sender, System.EventArgs e)
        {
            operationAppend("-");
        }

        private void Plusbtn_Click(object sender, System.EventArgs e)
        {
            operationAppend("+");
        }

        private void Btn9_Click(object sender, System.EventArgs e)
        {
            if (expressionText.Text == "0")
            {
                expressionText.Text = "9";
            }
            else
            {
                expressionText.Text += "9";
            }
        }

        private void Btn8_Click(object sender, System.EventArgs e)
        {
            if (expressionText.Text == "0")
            {
                expressionText.Text = "8";
            }
            else
            {
                expressionText.Text += "8";
            }
        }

        private void Btn7_Click(object sender, System.EventArgs e)
        {
            if (expressionText.Text == "0")
            {
                expressionText.Text = "7";
            }
            else
            {
                expressionText.Text += "7";
            }
        }

        private void Btn6_Click(object sender, System.EventArgs e)
        {
            if (expressionText.Text == "0")
            {
                expressionText.Text = "6";
            }
            else
            {
                expressionText.Text += "6";
            }
        }

        private void Btn5_Click(object sender, System.EventArgs e)
        {
            if (expressionText.Text == "0")
            {
                expressionText.Text = "5";
            }
            else
            {
                expressionText.Text += "5";
            }
        }

        private void Btn4_Click(object sender, System.EventArgs e)
        {
            if (expressionText.Text == "0")
            {
                expressionText.Text = "4";
            }
            else
            {
                expressionText.Text += "4";
            }
        }

        private void Btn3_Click(object sender, System.EventArgs e)
        {
            if (expressionText.Text == "0")
            {
                expressionText.Text = "3";
            }
            else
            {
                expressionText.Text += "3";
            }
        }

        private void Btn2_Click(object sender, System.EventArgs e)
        {
            if (expressionText.Text == "0")
            {
                expressionText.Text = "2";
            }
            else
            {
                expressionText.Text += "2";
            }
        }

        private void Btn1_Click(object sender, System.EventArgs e)
        {
            if(expressionText.Text == "0")
            {
                expressionText.Text = "1";
            }
            else { 
              expressionText.Text += "1";
            }
        }

        private void Btn0_Click(object sender, System.EventArgs e)
        {
            if (expressionText.Text != "0")
            {
                expressionText.Text += "0";
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void operationAppend(string op)
        {
            int textLength = expressionText.Text.Length;
            string lastChar = expressionText.Text.Substring(textLength - 1, 1);
            if (lastChar != "+" && lastChar != "-" && lastChar != "x" && lastChar != "÷")
            {
                expressionText.Text += op;
            }
            else
            {
                expressionText.Text = expressionText.Text.Remove(textLength - 1, 1);
                expressionText.Text += op;
            }
        }
    }
    public class Operation
    {
        public Operation LeftNumber { get; set; }
        public string Operator { get; set; }
        public Operation RightNumber { get; set; }

        private Regex additionSubtraction = new Regex("[+-]", RegexOptions.RightToLeft);
        private Regex multiplicationDivision = new Regex("[*/]", RegexOptions.RightToLeft);

        public void Parse(string equation)
        {
            var operatorLocation = additionSubtraction.Match(equation);
            if (!operatorLocation.Success)
            {
                operatorLocation = multiplicationDivision.Match(equation);
            }

            if (operatorLocation.Success)
            {
                Operator = operatorLocation.Value;

                LeftNumber = new Operation();
                LeftNumber.Parse(equation.Substring(0, operatorLocation.Index));

                RightNumber = new Operation();
                RightNumber.Parse(equation.Substring(operatorLocation.Index + 1));
            }
            else
            {
                Operator = "v";
                result = double.Parse(equation);
            }
        }

        private double result;

        public double Solve()
        {
            switch (Operator)
            {
                case "v":
                    break;
                case "+":
                    result = LeftNumber.Solve() + RightNumber.Solve();
                    break;
                case "-":
                    result = LeftNumber.Solve() - RightNumber.Solve();
                    break;
                case "*":
                    result = LeftNumber.Solve() * RightNumber.Solve();
                    break;
                case "/":
                    result = LeftNumber.Solve() / RightNumber.Solve();
                    break;
                default:
                    throw new Exception("Call Parse first.");
            }

            return result;
        }
    } }