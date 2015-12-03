﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dependencies;
using Design = Perspex.Design;

namespace Core2D.Perspex
{
    /// <summary>
    /// The Xaml designer helper class.
    /// </summary>
    public static class DesignerHelper
    {
        private static DesignerContext _dc;

        /// <summary>
        /// The Xaml designer DataContext object.
        /// </summary>
        public static object DataContext
        {
            get { return _dc == null ? null : _dc.Context; }
        }

        static DesignerHelper()
        {
            if (Design.IsDesignMode)
            {
                _dc = DesignerContext.Create(
                    new PerspexRenderer(),
                    new TextClipboard(),
                    new NewtonsoftSerializer());
            }
            else
            {
                // TODO: Remove after issue in binding to null is resolved.
                _dc = new DesignerContext()
                {
                    Context = new EditorContext()
                };
            }
        }
    }
}