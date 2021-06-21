Help Files are created in markdown, exported as HTML with MarkdownPad.
The .chm file is created with MS 'Html Help Workshop'.

When adding content, you'll need to edit:
   ZeroMungeHelp.hhp      (add the files)
   ZeroMungeHelp_TOC.hhc  (edit table of contents)

Basic structure is like:
 topic_start
 topic_gs
 topic_ui
    topic_ui_subtopic1
    topic_ui_subtopic2
    ...
 topic_menu
    topic_menu_subtopic1
    topic_menu_subtopic2
    ...

As you add more elements add them under 'topic_ui' and 'topic_cmd' in the 
'ZeroMungeHelp_TOC.hhc' file.