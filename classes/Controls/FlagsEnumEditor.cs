//===============================================================================================================
// System  : EWSoftware Design Time Attributes and Editors
// File    : FlagsEnumEditor.cs
// Author  : Eric Woodruff  (Eric@EWoodruff.us)
// Updated : 08/24/2014
// Note    : Copyright 2007-2014, Eric Woodruff, All rights reserved
// Compiler: Microsoft Visual C#
//
// This file contains a type editor that displays a checked list box as the drop-down editor for an enumerated
// data type that represents a set of flags.  This makes it easy to select multiple values with the drop-down.
//
// This code is published under the Microsoft Public License (Ms-PL).  A copy of the license should be
// distributed with the code.  It can also be found at the project website: https://GitHub.com/EWSoftware/SHFB.  This
// notice, the author's name, and all copyright notices must remain intact in all applications, documentation,
// and source files.
//
//    Date     Who  Comments
// ==============================================================================================================
// 07/25/2007  EFW  Created the code
//===============================================================================================================

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Mountain.classes.controls {

    /// <summary>
    /// This is a type editor that displays a checked list box as the drop-down
    /// editor for an enumerated data type that represents a set of flags.
    /// This makes it easy to select multiple values with the drop-down.
    /// </summary>
    
    public class FlagsEnumEditor : UITypeEditor {

        /// <summary>
        /// This is overridden to edit the value using a checked list box
        /// control as the drop-down editor.
        /// </summary>
        /// <param name="context">The descriptor context</param>
        /// <param name="provider">The provider</param>
        /// <param name="value">The enumerated type object to edit</param>
        /// <returns>The edited enumerated type object</returns>
        
        [RefreshProperties(RefreshProperties.All)]
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value) {
            IWindowsFormsEditorService editorService;
            Type enumType;
            Array enumValues;
            CheckedListBox checkbListBox;

            int bitIndex, bitCount;
            long flagsValue, itemValue, bit, newValue = 0;

            // Only use the editor if we have a valid context
            if (context == null || provider == null || context.Instance == null || value == null) return base.EditValue(context, provider, value);

            editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            if (editorService == null) return base.EditValue(context, provider, value);

            enumType = context.PropertyDescriptor.PropertyType;

#if DEBUG
            // It doesn't make sense to apply this to a non-flags enum so
            // in debug builds, validate it and throw an exception if it
            // doesn't meet the necessary criteria.
            object[] attributes = enumType.GetCustomAttributes(typeof(FlagsAttribute), true);

            if (attributes.Length == 0)
                throw new InvalidOperationException("FlagsEnumEditor must " +
                    "be applied to an enum that has the Flags attribute.");
#endif

            // Enums are generally 32-bit values but can be 8 or 64-bit
            // if a base type modifier is used.  We'll assume long to cover
            // all cases.

            flagsValue = Convert.ToInt64(value, CultureInfo.InvariantCulture);
            enumValues = Enum.GetValues(enumType);

            using (checkbListBox = new CheckedListBox()) {
                checkbListBox.BorderStyle = BorderStyle.None;
                checkbListBox.CheckOnClick = true;

                // Tahoma 8pt prevents it from clipping the bottom of each item
                checkbListBox.Font = new Font("Tahoma", 8.0f);

                // Load the values into the checked list box
                for (int index = 0; index < enumValues.Length; index++) {
                    itemValue = Convert.ToInt64(enumValues.GetValue(index), CultureInfo.InvariantCulture);

                    for (bitCount = bitIndex = 0, bit = 1; bitIndex < 64;
                      bitIndex++, bit <<= 1)
                        if ((itemValue & bit) != 0)
                            bitCount++;

                    // Ignore zero values (i.e. None) and values that are
                    // combinations of the flag values.
                    if (bitCount == 1) checkbListBox.Items.Add(enumValues.GetValue(index), (flagsValue & itemValue) == itemValue);
                }

                // Adjust the height of the list box to show all items or
                // at most twelve of them.
                if (checkbListBox.Items.Count < 12)
                    checkbListBox.Height = checkbListBox.Items.Count *
                        checkbListBox.ItemHeight;
                else
                    checkbListBox.Height = checkbListBox.Items.Count * 12;

                // Display it and let the user edit the value
                editorService.DropDownControl(checkbListBox);

                // Get the selected values and return the modified enum value
                for (int index = 0; index < checkbListBox.CheckedItems.Count; index++) {
                    itemValue = Convert.ToInt64(Enum.ToObject(enumType, checkbListBox.CheckedItems[index]), CultureInfo.InvariantCulture);
                    newValue = newValue | itemValue;
                }
            }

            return Enum.ToObject(enumType, newValue);
        }

        /// <summary>
        /// This is overridden to specify the editor's edit style
        /// </summary>
        /// <param name="context">The descriptor context</param>
        /// <returns>Always returns <b>DropDown</b> as long as there is a context and an instance.  Otherwise, it
        /// returns <c>None</c>.</returns>
        
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
            if (context != null && context.Instance != null) return UITypeEditorEditStyle.DropDown;
            return UITypeEditorEditStyle.None;
        }
    }
}
