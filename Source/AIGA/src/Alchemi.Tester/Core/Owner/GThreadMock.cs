#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  GThreadFiller.cs
* Project       :  Alchemi.Tester.Core.Owner
* Created on    :  19 April 2006
* Copyright     :  Copyright © 2006 Tibor Biro (tb@tbiro.com)
* Author        :  Tibor Biro (tb@tbiro.com)
* License       :  GPL
*                    This program is free software; you can redistribute it and/or
*                    modify it under the terms of the GNU General Public
*                    License as published by the Free Software Foundation;
*                    See the GNU General Public License
*                    (http://www.gnu.org/copyleft/gpl.html) for more 
details.
*
*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;

using Alchemi.Core.Owner;

namespace Alchemi.Tester.Core.Owner
{
    /// <summary>
    /// A test implementation of GThread
    /// </summary>
    class GThreadMock : GThread
    {
        private ThreadState _State = ThreadState.Unknown;

        public GThreadMock()
        {
            
        }

        public override void Start()
        {
            return;
        }

        public String GetWorkingDirectory()
        {
            return WorkingDirectory;
        }

        public override ThreadState State
        {
            get
            {
                return _State;
            }
        }

        public void SetState(ThreadState state)
        {
            _State = state;
        }
    }
}
