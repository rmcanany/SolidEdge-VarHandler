# SolidEdge-VarHandler

Inspired by a post on Siemens Community I decided to create this control center to easily evaluate variables range values

The actual version is limited and will perhaps be expanded per user requests


**Feature list:**
- Add any user variables ![Add](./Resources/icons8_add_16.png)
- Minimum and Maximum range retrieved from the variable table (if available)
- Ability to vary Minimum and Maximum range from the user interface (click on values to prompt)
- Exposed name retrieved from the variable table (if available)
- Ability to vary Exposed name from the variable table (double click on the title to prompt)
- Checkbox to auto-retrieve the variable on reload (**Autotune** on comments field) ![Autotune](./Resources/icons8_checked_checkbox_16.png)
- Remove button ![Autotune](./Resources/icons8_close_16.png)
- Play button, the trackbar will move to the end ![Autotune](./Resources/icons8_circled_play_16.png)
- Loop button, the trackbar will move from one end to the other and reverse continuously ![Autotune](./Resources/icons8_repeat_16.png)
- Reload button ![Autotune](./Resources/icons8_replay_16.png)
- Taskbar to easily change values
- Manuale vary the value (click on value to prompt)
- ReadOnly variables supported
- Works on any Solid Edge environment (par, psm, asm, dft)


Release versions [here](https://github.com/farfilli/SolidEdge-VarHandler/releases):
- 0.1 Very initial and rude one
- 0.2 Better error handling, variable selector and stay on top
- 0.3 Decimal support for initial value, Play button, Loop button, Stay on top, Manual value edit

**Known limits:**
- Only user variables supported
- mm, degree, and scalar units supported, other units will result in unpredicted values

Video in action [here](https://www.youtube.com/watch?v=izA-oFQAoVA&ab_channel=FrancescoArfilli)


**User UI:**

![MainForm](./MainForm.png)
![Variable selector](./VarSelector.png)

An example assembly is provided [here](./Crane.zip)
![Crane](./Crane.png)
![Variable table](./VarTable.png)
