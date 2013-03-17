﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetHack.GUI.Widgets
{
    /// <summary>
    /// Button
    /// </summary>
    [DebuggerDisplay("{Text}")]
    public class Button : Widget
    {
        readonly ButtonDecoration decoration;
        readonly char leftDecoration;
        readonly char rightDecoration;

        /// <summary>
        /// Create a new button
        /// </summary>
        public Button(String text, int x, int y, ButtonDecoration decor = ButtonDecoration.SquareBracket)
            : base(text, x, y, text.Length + 2, 1)
        {
            this.decoration = decor;
            switch (decor)
            {
                case ButtonDecoration.AngleBracket:
                    leftDecoration = DECORATION_ANGLE_L;
                    rightDecoration = DECORATION_ANGLE_R;
                    break;

                case ButtonDecoration.Stars:
                    leftDecoration = DECORATION_STAR;
                    rightDecoration = DECORATION_STAR;
                    break;
                case ButtonDecoration.SquareBracket:
                    leftDecoration = DECORATION_SQUARE_L;
                    rightDecoration = DECORATION_SQUARE_R;
                    break;
            }

            Text = string.Format("{0}{1}{2}", leftDecoration, text, rightDecoration);

            EnableSelection();

            KeyboardEvent += Button_KeyboardEvent;
        }

        /// <summary>
        /// InitializeWidget
        /// </summary>
        public override void InitializeWidget()
        {
            base.InitializeWidget();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Button_KeyboardEvent(object sender, Events.GUIKeyboardEventArgs e)
        {
            if (OkayCallback != null)
            {
                OkayCallback();
            }
        }

        /// <summary>
        /// Okay
        /// </summary>
        public Action OkayCallback { get; set; }

        /// <summary>
        /// Show
        /// </summary>
        public override void Show()
        {
            base.Show();

            for (int index = 0; index < Text.Length; ++index)
            {
                // normal text style
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;

                // decoration text style
                if (index == 0 || index == Text.Length - 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.BackgroundColor = ConsoleColor.White;

                    if (Selected)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Cyan;                       
                    }
                }

                Console.Write(Text[index]);
            }
        }

        /// <summary>
        /// ButtonDecoration
        /// </summary>
        public enum ButtonDecoration 
        {
            SquareBracket,
            AngleBracket,
            Stars
        }

        #region Various Decoration Constants

        /// <summary>
        /// The decoration on the right of the button
        /// </summary>
        const char DECORATION_SQUARE_R = ']';

        /// <summary>
        /// The decoration ont he left of the button
        /// </summary>
        const char DECORATION_SQUARE_L = '[';

        /// <summary>
        /// The decoration on the right of the button
        /// </summary>
        const char DECORATION_ANGLE_R = '>';

        /// <summary>
        /// The decoration ont he left of the button
        /// </summary>
        const char DECORATION_ANGLE_L = '<';

        /// <summary>
        /// The decoration on the right of the button
        /// </summary>
        const char DECORATION_STAR = '*';

        #endregion
    }
}