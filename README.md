# NewsParser

1. Написать парсер любого (одного, по выбору) новостного сайта и сохранить данные(тема, текст, дата) в БД.
2. Написать API  со следующими функциями:
    1. /api/posts?from=&to  Вернуть список новостей с фильтром по дате и времени from - to
    2. /api/topten/  Вернуть 10 самых часто используемых слов в новостях(тексте новости)
    3. /api/search?text=asd Вернуть новости в которых встречается текст(Поиск)
Не обязательно скачивать большое кол-во постов(~30 постов достаточно).
Необходимо использовать стек технологий .NET (c#), СУБД MS SQL Server Express.
У API может быть система аутентификации/авторизации (фантазия приветствуется).
Готовый проект нужно залить в github или что-нибудь наподобие.
Желательно, чтобы проект беспроблемно запускался после скачивания,
Также, желательно приложить краткое обоснование выбранной архитектуры и инструментов.
Смотрим на аккуратность выполнения, «чистоту» и читаемость кода. Следует это учесть.
