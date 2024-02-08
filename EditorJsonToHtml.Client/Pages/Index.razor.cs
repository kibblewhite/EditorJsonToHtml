namespace EditorJsonToHtml.Client.Pages;
public partial class Index
{
    public static readonly string EditorStyling = """
        [
            {
                "type": "header",
                "level": 1,
                "style": "specific-style",
                "id": "KgrM3aNM-n"
            },
            {
                "type": "header",
                "level": 3,
                "style": "general-style"
            },
            {
                "type": "paragraph",
                "style": "specific-style",
                "id": "NaTtEbbeRT"
            },
            {
                "type": "paragraph",
                "style": "general-style"
            },
            {
                "type": "list",
                "style": "list-group",
                "item-style": "list-group-item"
            },
            {
                "type": "checklist",
                "style": "general-style"
            },
            {
                "type": "quote",
                "style": "blockquote",
                "footer-style": "blockquote-footer"
            },
            {
                "type": "table",
                "style": "table table-hover"
            },
            {
                "type": "table",
                "style": "table table-striped",
                "id": "zOGIbPv7kl"
            }
        ]
        """;

    public static readonly string EditorJson = """
        {
          "time": 1707325917682,
          "blocks": [
            {
              "id": "KgrM3aNM-n",
              "type": "header",
              "data": {
                "text": "<mark class=\"cdx-marker\"><a href=\"http://google.com\">Heylo</a></mark>",
                "level": 1
              }
            },
            {
              "id": "NaTtEbbeRT",
              "type": "paragraph",
              "data": {
                "text": "Heylo World"
              }
            },
            {
              "id": "KgrM3aNM-n",
              "type": "header",
              "data": {
                "text": "Second header",
                "level": 3
              }
            },
            {
              "id": "QdqCFpKBAm",
              "type": "list",
              "data": {
                "style": "ordered",
                "items": [
                  {
                    "content": "A: One",
                    "items": [
                      {
                        "content": "B: Two",
                        "items": []
                      }
                    ]
                  },
                  {
                    "content": "A: Three",
                    "items": [
                      {
                        "content": "B: Four",
                        "items": [
                          {
                            "content": "C: Five",
                            "items": []
                          }
                        ]
                      },
                      {
                        "content": "B: Six",
                        "items": []
                      },
                      {
                        "content": "B: Seven",
                        "items": []
                      }
                    ]
                  }
                ]
              }
            },
            {
              "id": "m-onbmz6BZ",
              "type": "quote",
              "data": {
                "text": "Ohhh interesting...",
                "caption": "by Me!",
                "alignment": "left"
              }
            },
            {
              "id": "ZatOSzA754",
              "type": "paragraph",
              "data": {
                "text": "dsf<i>sfa</i><b>sfasdfs</b>dffasd"
              }
            },
            {
              "id": "SWrBNzvp6A",
              "type": "list",
              "data": {
                "style": "unordered",
                "items": [
                  {
                    "content": "dwdw",
                    "items": []
                  },
                  {
                    "content": "wedwed",
                    "items": []
                  },
                  {
                    "content": "wedw",
                    "items": []
                  }
                ]
              }
            },
        
            {
              "id": "yD5ZHUxF1N",
              "type": "checklist",
              "data": {
                "items": [
                  {
                    "text": "Check List Item One",
                    "checked": false
                  },
                  {
                    "text": "Check List Item Two",
                    "checked": true
                  },
                  {
                    "text": "Check List Item Three",
                    "checked": false
                  }
                ]
              }
            },
            {
              "id": "J5I_aD9c8j",
              "type": "delimiter",
              "data": {}
            },
            {
              "id": "J-7FqxXppm",
              "type": "table",
              "data": {
                "withHeadings": true,
                "content": [
                  [
                    "Header 1",
                    "Header 2",
                    "Header 3"
                  ],
                  [
                    "qwerty",
                    "as<b>dfg</b>h",
                    "zxc<mark class=\"cdx-marker\">vbn</mark>"
                  ],
                  [
                    "AAA",
                    "<a href=\"https://google.com/\">BBB</a>",
                    "<code class=\"inline-code\">CCC</code>"
                  ]
                ]
              }
            },
            {
              "id": "zOGIbPv7kl",
              "type": "table",
              "data": {
                "withHeadings": false,
                "content": [
                  [
                    "A1",
                    "B1"
                  ],
                  [
                    "A2",
                    "B2"
                  ]
                ]
              }
            }
          ],
          "version": "2.28.2"
        }
        """;
}