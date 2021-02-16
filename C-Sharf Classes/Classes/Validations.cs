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
using System.Windows.Forms;

namespace C_Sharf_Classes.Classes
{
    class Validations
    {
        public bool txtRequired(TextBox[] txt, string msg = "")
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
                if (msg != "")
                {
                    MessageBox.Show(msg);
                }
                else
                {
                    MessageBox.Show("Please fillup required fields!");
                }
                return false;
            }
            return true;
        }

        public bool cmbRequired(ComboBox[] cmb, string msg = "")
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
                if (msg != "")
                {
                    MessageBox.Show(msg);
                }
                else
                {
                    MessageBox.Show("Please fillup required fields!");
                }
                return false;
            }
            return true;
        }

        public void alpha(KeyPressEventArgs e)
        {
            // allows only letters
            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void num(KeyPressEventArgs e)
        {
            // allows only numbers
            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void alphanum(KeyPressEventArgs e)
        {
            // allows only letters & numbers
            if (!char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void specialchar(KeyPressEventArgs e)
        {
            // allows only special chars
            if (char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void alphaspaceback(KeyPressEventArgs e)
        {
            // allows only letters, numbers, space, backspace
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                if (e.KeyChar != (char)8) // BackSpace
                {
                    e.Handled = true;
                }
            }
        }

        public void numspaceback(KeyPressEventArgs e)
        {
            // allows only letters, numbers, space, backspace
            if (!char.IsNumber(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                if (e.KeyChar != (char)8) // BackSpace
                {
                    e.Handled = true;
                }
            }
        }

        public void alphanumspaceback(KeyPressEventArgs e)
        {
            // allows only letters, numbers, space, backspace
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                if (e.KeyChar != (char)8) // BackSpace
                {
                    e.Handled = true;
                }
            }
        }
 
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

    }
}
