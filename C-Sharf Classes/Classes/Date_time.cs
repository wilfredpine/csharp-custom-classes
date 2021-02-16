/**
 * __________________________________________________________________
 *
 * C-Sharf Custom Classes
 * __________________________________________________________________
 *
 * MIT License
 * 
 * Copyright (c) 2020 Wilfred V. Pine
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 *
 * @package C-Sharf Custom Classes
 * @author Wilfred V. Pine <only.master.red@gmail.com>
 * @copyright Copyright 2020 (https://red.confired.com)
 * @link https://confired.com
 * @license https://opensource.org/licenses/MIT MIT License
 */

using System;

namespace C_Sharf_Classes.Classes
{
    class Date_time
    {
        //instantiate public variables
        Public_variables public_vars = new Public_variables();

        public void date_format(string format)
        {
            public_vars.default_date_format = format;
        }

        public string reFormat(string date)
        {
            DateTime dt;
            var isValidDate = DateTime.TryParse(date, out dt);
            if (isValidDate)
                return dt.ToString(public_vars.default_date_format);
            else
                return $"{date} is not a valid date string";
        }

        public string toReadableDate(string date)
        {
            DateTime dt;
            var isValidDate = DateTime.TryParse(date, out dt);
            if (isValidDate)
                return dt.ToString("MMMM dd, yyyy");
            else
                return $"{date} is not a valid date string";
        }

        public string toTimeStamp(string date)
        {
            DateTime dt;
            var isValidDate = DateTime.TryParse(date, out dt);
            if (isValidDate)
                return dt.Ticks.ToString();
            else
                return $"{date} is not a valid date string";
        }

        public string getDate(string date)
        {
            DateTime dt;
            var isValidDate = DateTime.TryParse(date, out dt);
            if (isValidDate)
                return dt.Day.ToString();
            else
                return $"{date} is not a valid date string";
        }

        public string getMonth(string date)
        {
            DateTime dt;
            var isValidDate = DateTime.TryParse(date, out dt);
            if (isValidDate)
                return dt.Month.ToString();
            else
                return $"{date} is not a valid date string";
        }

        public string getYear(string date)
        {
            DateTime dt;
            var isValidDate = DateTime.TryParse(date, out dt);
            if (isValidDate)
                return dt.Year.ToString();
            else
                return $"{date} is not a valid date string";
        }
    }
}
