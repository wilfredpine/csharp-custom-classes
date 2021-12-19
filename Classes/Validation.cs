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
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Classes
{
    class Validation
    {
        /* Password encrypt
         * 
         */
            public string encodePassword(string password)
            {
                try
                {
                    byte[] encData_byte = new byte[password.Length];
                    encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                    return Convert.ToBase64String(encData_byte);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

        /* Password decrypt
         * 
         */
            public string decodePassword(string encodedData)
            {
                try
                {
                    System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                    System.Text.Decoder utf8Decode = encoder.GetDecoder();
                    byte[] todecode_byte = Convert.FromBase64String(encodedData);
                    int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                    char[] decoded_char = new char[charCount];
                    utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                    return new String(decoded_char);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

        /* Validate Required Textbox
         * return false if some fields are empty
         */
            public bool txtRequired(TextBox[] txt, bool allow_message = false, string msg = "Please fillup required fields!")
            {
                bool empt = false;
                foreach (TextBox tb in txt)
                {
                    if (tb.Text == null || tb.Text == "")
                    {
                        empt = true;
                    }
                }
                if (empt)
                {
                    if (allow_message)
                        MessageBox.Show(msg);
                    return false;
                }
                return true;
            }

        /* Validate Required ComboBox
         * return false if some fields are empty
         */
            public bool cmbRequired(ComboBox[] cmb, bool allow_message = false, string msg = "Please select required fields!")
            {
                bool empt = false;
                foreach (ComboBox cb in cmb)
                {
                    if (cb.SelectedIndex == -1 || cb.Text == "" || cb.Text == null)
                    {
                        empt = true;
                    }
                }
                if (empt)
                {
                    if (allow_message)
                        MessageBox.Show(msg);
                    return false;
                }
                return true;
            }

        /* Validate Email
         * return true if valid
         */
            public bool isEmailValid(TextBox txtEmail, string emailPattern = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", bool allow_message = false, string msg = "Invalid Email!")
            {
                bool valid = Regex.IsMatch(txtEmail.Text, emailPattern);
                if (!valid)
                {
                    if (allow_message)
                        MessageBox.Show(msg);
                    return false;
                }
                return true;
            }

        /* Validate Phone
         * return true if valid
         */
            public bool isPhoneValid(TextBox txtPhone, string phonePattern = @"^[2-9]\d{2}-\d{3}-\d{4}$", bool allow_message = false, string msg = "Invalid Phone!")
            {
                bool valid = Regex.IsMatch(txtPhone.Text, phonePattern);
                if (!valid)
                {
                    if (allow_message)
                        MessageBox.Show(msg);
                    return false;
                }
                return true;
            }

        /* Validate Zip
         * return true if valid
         */
            public bool isZipValid(TextBox txtZip, string zipPattern = @"^\d{3}\s?\d{3}$", bool allow_message = false, string msg = "Invalid Zip!")
            {
                bool valid = Regex.IsMatch(txtZip.Text, zipPattern);
                if (!valid)
                {
                    if (allow_message)
                        MessageBox.Show(msg);
                    return false;
                }
                return true;
            }

        /* Validate Custom Pattern
         * return true if valid
         */
            public bool isValidInput(TextBox[] txt, string Pattern, bool allow_message = false, string msg = "Something invalid in your inputs!")
            {
                bool valid = false;
                foreach (TextBox tb in txt)
                {
                    valid = Regex.IsMatch(tb.Text, Pattern);
                }
                if (valid)
                {
                    if(allow_message)
                        MessageBox.Show(msg);
                    return false;
                }
                return true;
            }

        /* Allows only letters
         * 
         */
            public void alpha(KeyPressEventArgs e)
            {
                if (!char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

        /* Allows only numbers
         * 
         */
            public void num(KeyPressEventArgs e)
            {
                if (!char.IsNumber(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

        /* Allows only letters & numbers
         * 
         */
            public void alphanum(KeyPressEventArgs e)
            {
                if (!char.IsLetterOrDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

        /* Allows only special characters
         * 
         */
            public void specialchar(KeyPressEventArgs e)
            {
                if (char.IsLetterOrDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

        /* Allows only letters, space, backspace
         * 
         */
            public void alphaspaceback(KeyPressEventArgs e)
            {
                if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                {
                    if (e.KeyChar != (char)8) // BackSpace
                    {
                        e.Handled = true;
                    }
                }
            }

        /* Allows only numbers, space, backspace
         * 
         */
            public void numspaceback(KeyPressEventArgs e)
            {
                if (!char.IsNumber(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                {
                    if (e.KeyChar != (char)8) // BackSpace
                    {
                        e.Handled = true;
                    }
                }
            }

        /* Allows only letters, numbers, space, backspace
         * 
         */
            public void alphanumspaceback(KeyPressEventArgs e)
            {
                if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                {
                    if (e.KeyChar != (char)8) // BackSpace
                    {
                        e.Handled = true;
                    }
                }
            }

        
    }
}
