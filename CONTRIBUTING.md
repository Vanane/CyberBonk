# Contributing to the project

Any contribution is welcome ! But in order for me to manage proposals and potential pull requests easily, here are some guidelines.

## Proposing a new functionality, reporting a bug

Before suggesting a new functionality, please first check the functionalities that are planned in the readme. If you can't find what you're proposing, you can create an issue on the repository, and mark it with the Suggestion label. use this too if you're suggesting an upgrade to an UI element, a sprite, or a model. **Don't hesitate to attach screenshots, mockups, and more to illustrate your suggestions !**

When suggesting a correction that doesn't involve coding (e.g. fixing an UI element or a sprite with rendering or scaling problems), you can use the Correction label.

For a minor bug report (e.g. missing or clipping props, enemies that should die but don't), use the Minor Bug flag.

For a game-breaking, or annoying bug, use the Issue flag.



When reporting a bug, please give as much information as you can :

- Small description of the problem
- What happened ?
- What did you do when it happened ?
- What should have happened instead ?
- If reproducible, how to reproduce ?
- Screenshots, error logs...

## Sending a Pull request

### Code quality

I'm not an expert in code quality, but I try to stick with these rules to try and keep consistency between the files (not that it's really important in the end).

- Variable names should be written in camelCase (e.g. itemName).
- Functions and classes should be written in CamelCase (e.g. ItemManager).
- Interfaces should be written in CamelCase, preceded with a capital I (e.g. ICollidable).
- Accessible fields don't need getters and setters, let it as public fields.
- Regarding the order in which class elements are sorted, I am trying to follow this order :
	- public fields
	- protected fields
	- private fields
	- public Unity-specific fields
	- protected Unity-specific fields
	- private Unity-specific fields
	- Constructor
	- public functions
	- private functions
- When creating/editing a class, make sure that you also modify the diagrams with the new functions, fields and classes.

