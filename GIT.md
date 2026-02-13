# JAK UŻYWAĆ GIT

## 1. Wprowadzenie
* Zainstaluj [git lfs](https://git-lfs.com/).
* Ściągnij repozytorium używając `git clone https://github.com/LudicLab7/vigilant-octo-enigma.git`
* Wejdź w utworzony folder w terminalu <small>(cmd/Powershell/git cmd/git bash)</small>
* Zainicjuj w nim git lfs przy użyciu `git lfs install` - konfiguracja jest już zrobiona (plik .gitattributes) 
* W unity hub kliknij "Dodaj projekt z dysku" lub "Add project from disk" -> wybierz folder `vigilant-octo-enigma`
![Dodaj -> dodaj projekt z dysku](https://i.imgur.com/CE9DHu6.png)
* Gotowe!

## 2. Jak używać git
* Przed rozpoczęciem pracy zawsze przełącz się na branch dev (`git checkout dev`) i zrób `git pull` (na dev, ważne że w tej kolejności) - zaoszczędzi ci to trochę pracy z merge'owaniem pull requestów
* Jeśli chcesz rozpocząć pracę nad nową funkcjonalnością, stwórz nowego brancha (`git branch [nazwa]`), nazwa powinna być w lowercase, bez znaków specjalnych i używając myślników zamiast spacji: np. `Updated readme.md` -> `updated-readme.md`
* <big>Zrób checkout!</big> Wykonaj `git checkout [nazwa-brancha]`, upewnij się że jesteś na poprawnym branchu!
* Wykonaj zmiany w kodzie - pamiętaj żeby wykonywać zmiany odpowiednie z przeznaczeniem brancha - od osobnych funkcji twórz osobne branche, zachowując odpowiednie nazewnictwo. Rób częste commity (`git add .`, `git commit`), możesz używać ich jako swojego rodzaju schowek, więcej informacji możesz znaleźć [tutaj](https://www.virtualmaker.dev/blog/git-and-unity-a-comprehensive-guide-to-version-control-for-game-devs). Pamiętaj o poprawnym nazewnictwie
* Jeśli skończyłeś twoje zadanie, zpushuj brancha na githuba za pomocą `git push -u origin [nazwa-brancha]` (nie dev! sprawdź czy na pewno byłeś na nowym branchu! visual studio znacznie to ułatwia przez gui). Pamiętaj o przetestowaniu twojego kodu, nawet jeśli jest bardzo prosty.
* Na githubie otwórz nowy pull request: ![Nowy pr](https://i.imgur.com/1CEj8Xe.png)
Wybierz branch do którego chcesz merge'ować (1), branch z którego chcesz merge'ować (2), Wybierz dobry tytuł oraz opis dla pull requesta - zwięzły tytuł i szczegółowy ale też zwięzły opis, w którym opisujesz co i jak zrobiłeś (nie jakoś super szczegółowo, bardziej na zasadzie "zrobiłem to i to używając tego i tego", tyle wystarczy. Jeśli bardzo nie chce ci się pisać, poproś chatbota) ![Nowy pr - wypełnienie formularza](https://i.imgur.com/nY9qyGf.png) Po stworzeniu pull requesta poczekaj na review, jeśli wystąpią problemy, napraw je. Po zaakceptowaniu pr'a zmerge'uj go do dev, jeśli akceptujący jeszcze tego nie zrobił.
