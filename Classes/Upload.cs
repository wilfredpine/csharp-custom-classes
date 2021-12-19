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

using System.IO;
using System.Windows.Forms;

namespace Classes
{
    class Upload
    {
        private string allowedFiles;
        private bool Multiselect;
        private string fileNameFullPath;
        private string fileNameWithoutExtension;
        private string newFileNameFullPath;

        public Upload(string allowedFiles = "Excel Files(.xls ,.xlsx)| *.xls ;*.xlsx|PDF Files(.pdf)|*.pdf|Text Files(*.txt)|*.txt|Word Files(.docx ,.doc)|*.docx;*.doc|Image Files(.jpg ,.jpeg, .png)|*.jpg;*.jpeg;*.png")
        {
            this.allowedFiles = allowedFiles;
            this.Multiselect = false;
        }

        public void browseFile(string newFileName)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = allowedFiles;
            dialog.Multiselect = Multiselect;

            if (dialog.ShowDialog() == DialogResult.OK)
            {

                //// get name of file with full path
                this.fileNameFullPath = dialog.FileName;

                //// getFile name without extension
                this.fileNameWithoutExtension = Path.GetFileNameWithoutExtension(this.fileNameFullPath);

                // get the extension
                string fileExtension = Path.GetExtension(this.fileNameFullPath);

                // new File name using Users Information
                // ex: juan_dela_cruz-division_name-position_title
                newFileName = newFileName.Replace(' ', '_');

                // new path + file with new name
                this.newFileNameFullPath = @"\" + newFileName + fileExtension;

            }
        }

        public void copyFileToDirectory(string path = @"c:\system_upload\")
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            //save to folder
            File.Copy(this.fileNameFullPath, path + this.newFileNameFullPath, true);
        }

    }
}
