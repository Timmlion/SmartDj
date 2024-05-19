<div align="center">
  <img src="docs/src/assets/logo.svg" height="75px">
</div>

<br />

<div align="center">
  <img alt="GitHub License" src="https://img.shields.io/github/license/timmlion/smartdj">
  <img alt="GitHub Release" src="https://img.shields.io/github/v/release/timmlion/smartdj">
</div>

<br />

# Wersja Polska / Polish Version

SmartDj to otwartoźródłowe rozwiązanie wspierające pracę DJ-ów i wodzirejów. Jego głównym zadaniem jest oferowanie prostego sposobu na zamawianie utworów z dedykacjami od uczestników wydarzenia. W planie są kolejne funkcjonalności, które będą rozwijane w zależności od potrzeb użytkowników. Narzędzie jest darmowe i każdy może z niego korzystać. Kod źródłowy jest dostępny na licencji AGPL-3.0.

## Funkcje

- 🎉 Web applet do zamawiania piosenek
- 👾 Panel do przeglądania i zarządzania zamówieniami oraz dodawania szablonów

## Opis działania

Aplikacja składa się z dwóch głównych elementów: panelu oraz serwera. Ten podział wynika z tego, że użytkownik może uruchomić serwer na innym urządzeniu i korzystać z panelu na innym urządzeniu. W przypadku, gdy serwer i panel są zainstalowane na jednym komputerze, łączą się ze sobą przez localhost. W przypadku, gdy maszyna, na której jest zainstalowany serwer, nie ma publicznego adresu IP (co jest dość częste), istnieje przygotowany serwer portr, który może być używany darmowo na potrzeby korzystania z oprogramowania SmartDj. Aby z niego skorzystać, należy skontaktować się ze mną w celu uzyskania klucza do połączenia z serwerem portr.

### Opis Panelu

Panel napisany jest w języku C# używając frameworka Blazor. Istnieje możliwość zainstalowania panelu jako aplikacji korzystając z możliwości PWA.

### Opis Serwera

Serwer to aplikacja webowa z REST API oraz bazą danych SQLite. Odpowiada za serwowanie formularza zamówień dla gości, przyjmowanie zamówień oraz całości kontaktu z panelem.

## Instrukcja instalacji

### Wersja całkowicie lokalna

*Instrukcje dotyczące instalacji wersji całkowicie lokalnej zostaną tutaj podane.*

## Licencja

Ten projekt jest licencjonowany na zasadach GNU Affero General Public License v3.0 (AGPL-3.0). Zobacz plik [LICENSE](/LICENSE), aby uzyskać pełny tekst licencji.

---

# English Version / Wersja Angielska

SmartDj is an open-source solution designed to support DJs and event hosts. Its primary function is to offer a simple way for event participants to request songs with dedications. More features are planned and will be developed based on user needs. The tool is free to use and the source code is available under the AGPL-3.0 license.

## Features

- 🎉 Web applet for song requests
- 👾 Panel for viewing and managing requests, and adding templates

## Description

The application consists of two main components: the panel and the server. This separation allows users to run the server on one device and access the panel from another. If both the server and the panel are installed on the same machine, they connect via localhost. In cases where the server does not have a public IP address (which is quite common), a prepared portr server can be used for free to meet the needs of SmartDj software. To use it, please contact me to obtain a connection key for the portr server.

### Panel Description

The panel is written in C# using the Blazor framework. It can be installed as a standalone application utilizing PWA capabilities.

### Server Description

The server is a web application with a REST API and an SQLite database. It handles serving the order form to guests, accepting orders, and communicating with the panel.

## Installation Instructions

### Fully Local Version

*Instructions for setting up a fully local version will be provided here.*

## License

This project is licensed under the GNU Affero General Public License v3.0 (AGPL-3.0). See the [LICENSE](/LICENSE) file for the full license text.
