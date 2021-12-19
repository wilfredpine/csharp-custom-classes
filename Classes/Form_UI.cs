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

using System.Drawing;
using System.Windows.Forms;

namespace Classes
{
    class Form_UI
    {
        #region Default

            /* Show next then hide the current
             * 
             */
                public void Show(Form frmNew, Form frmOld)
                {
                    frmNew.Show();
                    frmOld.Hide();
                }

            /* Show Form as dialog box (Focus Mode)
             * 
             */
                public void Dialog(Form frm)
                {
                    frm.ShowDialog();
                }

        #endregion

        #region Multiple Document Interface

            /* MDI show form
             * 
             */
                public void FormShow(Form frm, string dstyle = "Fill")
                {
                    Form formMain = new Form() { FormBorderStyle = FormBorderStyle.None };
                    // get the active MDI container
                    foreach (Form formActive in Application.OpenForms)
                    {
                        if(formActive.IsMdiContainer == true)
                        {
                            formMain = formActive;
                        }
                    }
                    // close active child form
                    try
                    {
                        Form fr = new Form() { FormBorderStyle = FormBorderStyle.None };

                        fr.MdiParent = formMain;
                        fr.Dock = DockStyle.Fill;
                        fr.Show();
                        foreach (Form child in formMain.MdiChildren)
                        {
                            child.Close();
                        }
                    }
                    catch { }
                    
                    // show child form
                    frm.MdiParent = formMain;
                    switch (dstyle)
                    {
                        case "Fill":
                            frm.Dock = DockStyle.Fill;
                            break;
                        case "Top":
                            frm.Dock = DockStyle.Top;
                            break;
                        case "Right":
                            frm.Dock = DockStyle.Right;
                            break;
                        case "Bottom":
                            frm.Dock = DockStyle.Bottom;
                            break;
                        case "Left":
                            frm.Dock = DockStyle.Left;
                            break;
                        default:
                            frm.Dock = DockStyle.None;
                            break;
                    }
                    frm.Show();
                }

            /* MDI active menu
             * 
             */
                public void active(string form, Button btn, Color col, Button[] menu, Color def_color)
                {
                    // reset backcolor of menu
                    foreach (Button button in menu)
                    {
                        button.BackColor = def_color;
                    }

                    Form formMain = new Form() { FormBorderStyle = FormBorderStyle.None };

                    // get the active MDI form
                    foreach (Form formActive in Application.OpenForms)
                    {
                        if (formActive.IsMdiContainer == true)
                        {
                            formMain = formActive;
                        }
                    }

                    // change backcolor of active menu
                    foreach (Form child in formMain.MdiChildren)
                    {
                        if (child.Name.ToString() == form)
                        {
                            btn.BackColor = col;
                        }
                    }


                }

        #endregion
    }
}
