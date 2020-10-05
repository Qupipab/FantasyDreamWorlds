# About

Fantasy Dream Worlds is a game project based on reworked high quality [FTB][FTB] modpacks and maps for Minecraft.  
It provides the ability to play on popular builds such as [Infinity Evolved][Infinity] and [Project Ozone 2][Ozone], as well as several custom builds.

**P.S. The project is under development**

---

## Created with 

* ASP.NET Core
* EF Core
* Vue CLI
* Scss
* BootstrapVue
* PostgreSQL

---

## Features

* Dark theme
* Localisation
* Adaptability
* Pop-up notifications

---

## Theme
  Dark Mode is a supplemental mode that can be used to display mostly dark surfaces on the UI. The advantages of Dark Mode are, it enhances visual ergonomics by reducing eye strain, facilitating screens to adjust according to current light conditions and providing comfort of use at night or in dark environments.
<details>
  <summary>Details</summary>

  [Issue #6][iss6]  
  [Switch componentn code][isc6]

</details>
<img title="Theme" alt="Theme" src="https://user-images.githubusercontent.com/54445583/95020636-f9b08400-0674-11eb-9ed0-1932f21ca98f.gif" />

---

## Auth
  Authorization allows you to upload your character skins, buy items and resources from the store and other perks.
<details>
  <summary>Details</summary>
  Registration is implemented through ASP.NET Core Identity. Authorization with JSON Web Tokens. Front-end validation is implemented using the Vuelidate library, and server validation errors through popup notifications.

  Auth code: [1][isc8_1] [2][isc8_2]

</details>
<img title="SignUp" width="700px" alt="SignUp" src="https://user-images.githubusercontent.com/54445583/95021523-1ef3c100-067a-11eb-8a7a-5683a049154e.gif" />
<img title="SignIn" width="700px" alt="SignIn" src="https://user-images.githubusercontent.com/54445583/95021631-c7098a00-067a-11eb-98d6-5f4e3874df38.gif" />

---

## Game Servers
On the pages of game servers, you can see a description of a specific game branch, as well as find out more detailed information about the configuration and modifications of the game server.  

Also FDW has English localization.
<details>
  <summary>Details</summary>
  The i18n library was used for localization. You can switch the language both using the switch in the footer and using the address bar.  
    
  [Localisation issue][iss21]  
  Localisation code: [1][isc21_1] [2][isc21_2] [3][isc21_3] [4][isc21_4]  
  
  [Game servers issue][iss27]  
  [Game servers code][isc27]

  
</details>
<img title="GameServers" alt="GameServers" src="https://user-images.githubusercontent.com/54445583/95022424-e9ea6d00-067f-11eb-9547-c1836c5636a8.gif" />

---

## Mobile menu
<details>
  <summary>Details</summary>
  The sass preprocessor was used. Layout made using flexbox and grid.
</details>
<img title="MobileMenu" alt="MobileMenu" src="https://user-images.githubusercontent.com/54445583/95022890-7b5ade80-0682-11eb-8a18-48852d45e4ab.gif" />

---

## Sidebar
The sidebar allows you to view the current online on the game servers, the general information on the game branch is displayed in an unfolded form, in the expanded form, more detailed information about the online on the servers of the branch is displayed.
<details>
  <summary>Details</summary>

  [Sidebar code][isc10]

</details>
<img title="Sidebar" alt="Sidebar" src="https://user-images.githubusercontent.com/54445583/95023014-426f3980-0683-11eb-9f15-28b5d56702a6.gif" />

---

## Commands page
Commands are used to communicate between the game and the web server. For example, to privatize a territory or change a region inside.
<details>
  <summary>Details</summary>

  [Commands page code][isc35]

</details>
<img title="Commands" alt="Commands" src="https://user-images.githubusercontent.com/54445583/95023261-c2e26a00-0684-11eb-9c35-9c8d43de9f2f.gif" />

---

## Rules page
Description
<details>
  <summary>Details</summary>
</details>
<img title="Rules" alt="Rules" src="https://user-images.githubusercontent.com/54445583/95023346-384e3a80-0685-11eb-9d94-f0225a20742a.gif" />

---

## FAQ page
Frequently asked questions, HTML anchor link implemented.
<details>
  <summary>Details</summary>
  
  [FAQ code][isc63]
  
</details>
<img title="Rules" alt="Rules" src="https://user-images.githubusercontent.com/54445583/95023590-9596bb80-0686-11eb-93e5-62b5111b789f.gif" />

---

## Shop page
Description
<details>
  <summary>Details</summary>
  test
</details>
<img title="Shop" alt="Shop" src="https://user-images.githubusercontent.com/54556157/95026992-d817c280-069d-11eb-960a-77f9b9786d26.gif" />

---

## API | Swagger
Description
<details>
  <summary>Details</summary>
  test
</details>

[FTB]: https://www.feed-the-beast.com/
[Infinity]: https://www.curseforge.com/minecraft/modpacks/ftb-infinity-evolved
[Ozone]: https://www.curseforge.com/minecraft/modpacks/project-ozone-2-reloaded

[isc6]: https://github.com/Qupipab/FantasyDreamWorlds/tree/master/client/src/components/controls/fdw-theme-switch
[iss6]: https://github.com/Qupipab/FantasyDreamWorlds/issues/6

[isc8_1]: https://github.com/Qupipab/FantasyDreamWorlds/tree/master/client/src/components/fdw-auth
[isc8_2]: https://github.com/Qupipab/FantasyDreamWorlds/blob/master/Server/WebAPI/Services/AuthService.cs

[iss21]: https://github.com/Qupipab/FantasyDreamWorlds/issues/21
[isc21_1]: https://github.com/Qupipab/FantasyDreamWorlds/blob/master/client/src/services/i18n/get-browser-locale.js
[isc21_2]: https://github.com/Qupipab/FantasyDreamWorlds/tree/master/client/src/components/controls/fdw-locale-select
[isc21_3]: https://github.com/Qupipab/FantasyDreamWorlds/tree/master/client/src/components/utils/localized-link
[isc21_4]: https://github.com/Qupipab/FantasyDreamWorlds/tree/master/client/src/locales

[iss27]: https://github.com/Qupipab/FantasyDreamWorlds/issues/27
[isc27]: https://github.com/Qupipab/FantasyDreamWorlds/tree/master/client/src/views/server-info

[isc10]: https://github.com/Qupipab/FantasyDreamWorlds/tree/master/client/src/components/fdw-sidebar

[isc35]: https://github.com/Qupipab/FantasyDreamWorlds/tree/master/client/src/views/commands

[isc63]: https://github.com/Qupipab/FantasyDreamWorlds/tree/master/client/src/views/faq
