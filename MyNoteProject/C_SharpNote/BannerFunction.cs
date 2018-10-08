using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpNote
{
    /// <summary>
    /// 動態執行方法function
    /// </summary>
    public class BannerFunction
    {
        public string layout_html(int layout_Id)
        {
            MethodInfo[] metInfos = this.GetType().GetMethods(); //取得所有方法
            foreach (MethodInfo info in metInfos)
            {
                if (info.Name == "GetLayout" + layout_Id.ToString())
                {
                    info?.Invoke(this, null);
                }
            }
            string html = "";
            switch (layout_Id)
            {
                case 2:
                    html = GetLayout_2();
                    break;
                case 3:
                    html = GetLayout_3();
                    break;
                case 4:
                    html = GetLayout_4();
                    break;
                case 5:
                    html = GetLayout_5();
                    break;
                case 6:
                    html = GetLayout_6();
                    break;
                case 7:
                    html = GetLayout_7();
                    break;
                case 8:
                    html = GetLayout_8();
                    break;
                case 9:
                    html = GetLayout_9();
                    break;
                case 10:
                    html = GetLayout_10();
                    break;
                case 11:
                    html = GetLayout_11();
                    break;
                case 12:
                    html = GetLayout_12();
                    break;
                case 13:
                    html = GetLayout_13();
                    break;
                case 20:
                    html = GetLayout_20();
                    break;
                case 21:
                    html = GetLayout_21();
                    break;
                case 30:
                    html = GetLayout_30();
                    break;
            }

            return html;
        }

        private string GetLayout_13()
        {
            return @"<section class=""af-part layout-base af-hero layout-2   {original.class}"" style=""{style}"">
                     <a class=""link-area"" href=""{original.link}"" target=""{original.target}""  alt=""{original.description}"" title=""{original.linktext}""  data-track=""banner-main""  onclick=""GABannerTrackEvent(this);return false;""
>{original.linktext}</a>
                     <div class=""inner"">
                     <div class=""group-block group-1 block-1  _ex {original.group1_class}"">
                     </div>
                     </div>
                     </section>";
        }

        private string GetLayout_12()
        {
            return @"<section class=""af-part layout-base af-hero layout-1 {original.class}"" style=""{style}"">
                     <a class=""link-area"" href=""{original.link}"" target=""{original.target}""  alt=""{original.description}"" title=""{original.linktext}""  data-track=""banner-main""   onclick=""GABannerTrackEvent(this);return false;""
>{original.linktext}</a>
                     <div class=""inner"">
                     <div class=""group-block group-1  _ex {original.group1_class}"">
                     </div>
                     <div class=""group-block group-2   _ex {original.group2_class}"">
                     </div>
                     </div>
                     </section>";
        }

        private string GetLayout_11()
        {
            return @"<section class=""af-part af-two-cols grids grids l__grid-1x2 s__grid-1 af-third  {original.class}""  style=""{style}"">
                     <div class=""inner"">
                     <div class=""group-block group-1 grid"">
                        <a class=""link-area"" href=""{original.link}""   target=""{original.target}""   alt=""{original.description}""  title=""{original.linktext}"" data-track=""banner-fold2-1""  onclick=""GABannerTrackEvent(this);return false;"">{original.linktext}</a>
                        <div class=""product-info"">
                            <div class=""group  _ex {original.group1_class}""></div>
                        </div>
                        <div class=""product-img pic _ex {original.group1_class}""></div>
                     </div>
                     <div class=""group-block group-2 grid"">
                        <a class=""link-area"" href=""{original.link2}""   target=""{original.target2}""   alt=""{original.description2}""  title=""{original.linktext2}"" data-track=""banner-fold2-2""  onclick=""GABannerTrackEvent(this);return false;"">{original.linktext2}</a>
                        <div class=""product-info"">
                            <div class=""group  _ex {original.group2_class}""></div>
                        </div>
                        <div class=""product-img pic _ex {original.group2_class}""></div>
                     </div>
                     </div>
                     </section>";
        }

        private string GetLayout_10()
        {
            return @"<section class=""af-part layout-base af-hero hero-layout-4  {original.class}"" style=""{style}"">
                     <a class=""link-area"" href=""{original.link}""  target=""{original.target}""   alt=""{original.description}""  title=""{original.linktext}"" data-track=""banner-main""  onclick=""GABannerTrackEvent(this);return false;"">{original.linktext}</a>
                     <div class=""inner"">
                     <div class=""group-block group-1 block-1 _ex {original.group1_class}"">
                     </div>
                     <div class=""group-block group-2 _ex {original.group2_class}"">
                     </div>
                     </div>
                     </section>";
        }

        private string GetLayout_9()
        {
            return @"<section class=""af-part layout-base #sort_css# layout-6  {original.class}"" style=""{style}"">
                     <a class=""link-area"" href=""{original.link}""  target=""{original.target}""   alt=""{original.description}""  title=""{original.linktext}"" data-track=""#sort_track#""  onclick=""GABannerTrackEvent(this);return false;""
>{original.linktext}</a>
                     <div class=""inner"">
                     <div class=""group-block group-1 _ex {original.group1_class}"">
                     </div>
                     <div class=""group-block group-2 _ex {original.group2_class}"">
                     </div>
                     </div>
                     </section>";
        }

        private string GetLayout_8()
        {
            return @"<section class=""af-part layout-base #sort_css# layout-5  {original.class}"" style=""{style}"">
                     <a class=""link-area"" href=""{original.link}"" target=""{original.target}""  alt=""{original.description}"" title=""{original.linktext}"" data-track=""#sort_track#""  onclick=""GABannerTrackEvent(this);return false;""
>{original.linktext}</a>
                     <div class=""inner"">
                     <div class=""group-block group-1 _ex {original.group1_class}"">
                     </div>
                     <div class=""group-block group-2 _ex {original.group2_class}"">
                     </div>
                     </div>
                     </section>";
        }

        private string GetLayout_7()
        {
            return @"<section class=""af-part layout-base #sort_css# layout-4 {original.class}"" style=""{style}"">
                     <a class=""link-area"" href=""{original.link}"" target=""{original.target}""  alt=""{original.description}"" title=""{original.linktext}"" data-track=""#sort_track#""  onclick=""GABannerTrackEvent(this);return false;""
>{original.linktext}</a>
                     <div class=""inner"">
                     <div class=""group-block group-1 _ex {original.group1_class}"">
                     </div>
                     <div class=""group-block group-2 _ex {original.group2_class}"">
                     </div>
                     </div>
                     </section>";
        }

        private string GetLayout_6()
        {
            return @"<section class=""af-part layout-base #sort_css# layout-3  {original.class}"" style=""{style}"">
                     <a class=""link-area"" href=""{original.link}"" target=""{original.target}""  alt=""{original.description}"" title=""{original.linktext}"" data-track=""#sort_track#""  onclick=""GABannerTrackEvent(this);return false;""
>{original.linktext}</a>
                     <div class=""inner"">
                     <div class=""group-block group-1  _ex {original.group1_class}"">
                     </div>
                     <div class=""group-block group-2  _ex {original.group2_class}"">
                     </div>
                     </div>
                     </section>";
        }

        private string GetLayout_5()
        {
            return @"<section class=""af-part layout-base #sort_css# layout-2   {original.class}"" style=""{style}"">
                     <a class=""link-area"" href=""{original.link}"" target=""{original.target}""  alt=""{original.description}"" title=""{original.linktext}"" data-track=""#sort_track#""  onclick=""GABannerTrackEvent(this);return false;""
>{original.linktext}</a>
                     <div class=""inner"">
                     <div class=""group-block group-1 block-1  _ex {original.group1_class}"">
                     </div>
                     </div>
                     </section>";
        }

        private string GetLayout_4()
        {
            return @"<section class=""af-part layout-base #sort_css# layout-1 {original.class}"" style=""{style}"">
                     <a class=""link-area"" href=""{original.link}"" target=""{original.target}""  alt=""{original.description}"" title=""{original.linktext}"" data-track=""#sort_track#""  onclick=""GABannerTrackEvent(this);return false;""
>{original.linktext}</a>
                     <div class=""inner"">
                     <div class=""group-block group-1  _ex {original.group1_class}"">
                     </div>
                     <div class=""group-block group-2   _ex {original.group2_class}"">
                     </div>
                     </div>
                     </section>";
        }

        private string GetLayout_3()
        {
            return @"<section class=""af-part layout-base af-hero hero-layout-3  {original.class}"" style=""{style}"" data-track=""banner-main""  onclick=""GABannerTrackEvent(this);return false;"">
                     <a class=""link-area"" href=""{original.link}"" target=""{original.target}""  alt=""{original.description}"" title=""{original.linktext}"">{original.linktext}</a>
                     <div class=""inner"">
                     <div class=""group-block group-1 _ex {original.group1_class}"">
                     </div>
                     <div class=""group-block group-2 _ex  {original.group2_class}"">
                     </div>
                     </div>
                     </section> ";
        }

        private string GetLayout_2()
        {
            return @"<section class=""af-part layout-base af-hero hero-layout-2 {original.class}"" style=""{style}"">
                    <a class=""link-area"" href=""{original.link}"" target=""{original.target}""  alt=""{original.description}"" title=""{original.linktext}"" data-track=""banner-main""  onclick=""GABannerTrackEvent(this);return false;"">{original.linktext}</a>
                    <div class=""inner"">
                    <div class=""group-block group-1 _ex {original.group1_class}"">
                    </div>
                    <div class=""group-block group-2 _ex  {original.group2_class}"">
                    </div>
                    </div>
                    </section>";
        }

        private string GetLayout_30()
        {
            return @"
                <section class=""af-banner af-ss-banner af-banner_x3"" >
                <a href=""{original.Banners[0].link}"" target=""{original.Banners[0].target}"">
                <div class=""banner-block {original.Banners[0].class} "" style=""{style0}"" >
                    <div class=""banner-inner"">
                      <div class=""banner-wrap"">
                        <div class=""banner-img group-block group-1 _ex ""></div>
                        <div class=""banner-info"">
        	                <div class=""group-block group-2 _ex ""> 	</div>        
					                <div class=""btn-group  group-block group-3 _ex ""> </div>
      	                </div>
                    </div>
                  </div>
                </div> 
                 </a>

                <a href=""{original.Banners[1].link}"" target=""{original.Banners[1].target}"">
                  <div class=""banner-block {original.Banners[1].class}"" style=""{style1}"" >
                    <div class=""banner-inner"">
                      <div class=""banner-wrap"">
                        <div class=""banner-img group-block group-1 _ex ""></div>
                        <div class=""banner-info"">
        	                <div class=""group-block group-2 _ex ""> 	</div>        
					                <div class=""btn-group  group-block group-3 _ex ""> </div>
                      </div>
                    </div>
                  </div>
                </div>
                 </a>

                <a href=""{original.Banners[1].link}"" target=""{original.Banners[2].target}"">
                  <div class=""banner-block {original.Banners[2].class}"" style=""{style2}"" >
                    <div class=""banner-inner"">
                      <div class=""banner-wrap"">
                        <div class=""banner-img group-block group-1 _ex ""></div>
                        <div class=""banner-info"">
        	                <div class=""group-block group-2 _ex ""> 	</div>        
					                <div class=""btn-group  group-block group-3 _ex ""> </div>
                      </div>
                    </div>
                  </div>    
                </div>
                </a>

                <a href=""{original.Banners[1].link}"" target=""{original.Banners[3].target}"">
                  <div class=""banner-block {original.Banners[3].class}"" style=""{style3}"" >
                    <div class=""banner-inner"">
                      <div class=""banner-wrap"">
                        <div class=""banner-img group-block group-1 _ex ""></div>
                        <div class=""banner-info"">
        	                <div class=""group-block group-2 _ex ""> 	</div>        
					                <div class=""btn-group  group-block group-3 _ex ""> </div>
                      </div>
                    </div>
                  </div>
                </div>
                </a>
                </section>
                ";
        }

        private string GetLayout_21()
        {
            return @"
                    <section class=""af-sub-banner af-banner  {original.class}"" style=""{style0}"" >
                      <div class=""banner-block info-on-left"">
                        <div class=""banner-inner"">
                          <div class=""banner-wrap group-block group-1 _ex {original.group1_class} "">
                            <div class=""banner-info group-block group-2 _ex {original.group2_class}"">
                            </div>
                          </div>
                        </div>
                      </div>
                    </section>
                    ";
        }

        private string GetLayout_20()
        {
            return @" 
                <section class=""af-banner  af-top-banner product-index-banner "" style=""{style0}"">
                <a href=""{original.Banners[0].link}"" target=""{original.Banners[0].target}"">
                  <div class=""banner-block  {original.Banners[0].class}"">
                    <div class=""banner-inner"">
                      <div class=""banner-wrap"">
                        <div class=""banner-img group-block group-1 _ex {original.Banners[0].group1_class}""></div>
                        <div class=""banner-info"">
        	                <div class=""group-block group-2 _ex {original.Banners[0].group2_class}""></div>        
					                <div class=""btn-group  group-block group-3 _ex {original.Banners[0].group3_class}""></div>
      	                </div>
    	                </div>
                    </div>
                  </div>
                </a>
                </section>
                ";
        }
    }
}
