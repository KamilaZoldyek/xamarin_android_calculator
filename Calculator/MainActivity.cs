﻿using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Calculator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private TextView calculatorText;

        private string[] numbers = new string[2];
        private string @operator;

        protected override void OnCreate(Bundle savedInstanceState)
        {
 
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            calculatorText = FindViewById<TextView>(Resource.Id.calculator_text_view);


        }
        [Java.Interop.Export("ButtonClick")]
        public void ButtonClick(View v)
        {
            Button button = (Button)v;
            if ("0123456789.".Contains(button.Text))
                AddDigitOrDecimalPoint(button.Text);
            else if ("/*+-".Contains(button.Text))
                AddOperator(button.Text);
            else if ("=" == button.Text)
                Calculate();
            else
                Erase();
        }

        private void AddDigitOrDecimalPoint(string value)
        {
            int index = @operator == null ? 0 : 1;
            if(value == "." && numbers[index].Contains("."))
                return;
            numbers[index] += value;

            UpdateCalculatorText();
        }

        private void AddOperator(string text)
        {

        }

        private void Calculate()
        {

        }

        private void Erase()
        {

        }

        private void UpdateCalculatorText() =>  calculatorText.Text = $"{numbers[0]} {@operator} {numbers[1]}";

    }



}


