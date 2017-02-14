using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
//
using System.Web.Mvc;

/// <summary>
/// MvcExtensions 控件扩展类
/// </summary>
public static class MvcExtensions
{
    /// <summary>
    /// CheckBoxList 自定义控件
    /// </summary>
    /// <param name="helper"></param>
    /// <param name="name"></param>
    /// <param name="category"></param>
    /// <param name="items"></param>
    /// <returns></returns>
    public static MvcHtmlString CheckBoxList(this HtmlHelper helper, string parent_name, string name, List<string> categories, List<CheckBoxObject> items)
    {
        var str = new StringBuilder();

        if (items != null)
        {
            if (categories != null)
            {
                foreach (string category in categories)
                {
                    str.Append("<dl class=\"permission-list\">");

                    str.Append("<dt>");
                    str.Append("<label>");
                    str.Append("<input type=\"checkbox\" value=\"\" name=\"\" class=\"select_all\">");
                    str.Append(category);
                    str.Append("</label>");
                    str.Append("</dt>");

                    if (items != null)
                    {
                        str.Append("<dd>");

                        foreach (CheckBoxObject item in items)
                        {
                            str.Append("<dl class=\"cl permission-list2\">");

                            if (!string.IsNullOrEmpty(item.Title))
                            {
                                str.Append("<dt>");
                                str.Append("<label class=\"\">");
                                str.Append("<input type=\"checkbox\" value=\"" + item.Value + "\" name=\"" + parent_name + "\" class=\"select_item_all\">");
                                str.Append(item.Title);
                                str.Append("</label>");
                                str.Append("</dt>");
                            }

                            if (item.Datas != null)
                            {
                                if (!string.IsNullOrEmpty(item.Title))
                                {
                                    str.Append("<dd>");
                                }
                                else
                                {
                                    str.Append("<dd style=\"margin-left: 0px\">");
                                }

                                foreach (SelectListItem obj in item.Datas)
                                {
                                    str.Append("<label class=\"\">");

                                    if (!string.IsNullOrEmpty(item.Title))
                                    {
                                        str.Append("<input type=\"checkbox\" value=\"" + item.Value + "_" + obj.Value + "\" name=\"" + name + "\" " + (obj.Selected ? "checked=\"checked\"" : "") + ">");
                                    }
                                    else
                                    {
                                        str.Append("<input type=\"checkbox\" value=\"" + obj.Value + "\" name=\"" + name + "\" " + (obj.Selected ? "checked=\"checked\"" : "") + ">");
                                    }

                                    str.Append(obj.Text);
                                    str.Append("</label>");
                                }
                                str.Append("</dd>");
                            }
                            str.Append("</dl>");
                        }
                        str.Append("</dd>");
                    }
                    str.Append("</dl>");
                }
            }
        }

        return MvcHtmlString.Create(str.ToString());
    }

    /// <summary>
    /// .label-default 默认|.label-primary 主要|.label-secondary 次要|.label-success 成功|.label-warning 警告|.label-danger 危险
    /// </summary>
    public enum SpanLevel
    {
        Default,
        Primary,
        Secondary,
        Success,
        Warning,
        Danger
    }

    /// <summary>
    /// 不同的span标签颜色，根据级别来定
    /// </summary>
    /// <param name="helper"></param>
    /// <param name="text"></param>
    /// <returns></returns>
    public static MvcHtmlString SpanText(this HtmlHelper helper, string text, SpanLevel level)
    {
        var str = new StringBuilder();

        if (!string.IsNullOrEmpty(text))
        {
            switch (level)
            {
                case SpanLevel.Default:
                    str.Append(string.Format("<span class=\"label {0} radius\">{1}</span>", "label-default", text));
                    break;
                case SpanLevel.Primary:
                    str.Append(string.Format("<span class=\"label {0} radius\">{1}</span>", "label-primary", text));
                    break;
                case SpanLevel.Secondary:
                    str.Append(string.Format("<span class=\"label {0} radius\">{1}</span>", "label-secondary", text));
                    break;
                case SpanLevel.Success:
                    str.Append(string.Format("<span class=\"label {0} radius\">{1}</span>", "label-success", text));
                    break;
                case SpanLevel.Warning:
                    str.Append(string.Format("<span class=\"label {0} radius\">{1}</span>", "label-warning", text));
                    break;
                case SpanLevel.Danger:
                    str.Append(string.Format("<span class=\"label {0} radius\">{1}</span>", "label-danger", text));
                    break;
            }
        }

        return MvcHtmlString.Create(str.ToString());
    }
}

public class CheckBoxObject
{
    /// <summary>
    /// 模块文字
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// 显示文字
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// 值
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// 数据
    /// </summary>
    public List<SelectListItem> Datas { get; set; }

    /// <summary>
    /// 是否选中
    /// </summary>
    public bool Selected { get; set; }
}