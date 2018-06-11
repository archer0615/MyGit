using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Builder_Pattern
{
    public class Profile
    {
        public Profile(Context context, string userId,
                   bool isActivated, UserEvent _event, Theme theme)
        {

        }
        public  class Builder
        {

            private Context mContext;
            private string mUserId;
            private bool mIsActivated = false;
            private UserEvent mEvent = null;
            private Theme mTheme = null;

            public Builder(Context context, String userId)
            {
                mContext = context;
                mUserId = userId;
            }

            public Builder setIsActivated(bool isActivated)
            {
                mIsActivated = isActivated;
                return this;
            }

            public Builder setUserEvent(UserEvent _event)
            {
                mEvent = _event;
                return this;
            }

            public Builder setTheme(Theme theme)
            {
                mTheme = theme;
                return this;
            }

            public Profile build()
            {
                return new Profile(mContext, mUserId, mIsActivated, mEvent, mTheme);
            }
        }
    }
   
    public class UserEvent
    {
    }
    public class Context
    {
    }
    public class Theme
    {
    }
}


