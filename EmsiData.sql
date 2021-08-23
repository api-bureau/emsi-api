CREATE TABLE [Skills] (
  [Id] TEXT NOT NULL
, [InfoUrl] TEXT NOT NULL
, [Name] TEXT NOT NULL
, [RemovedDescription] TEXT NULL
, CONSTRAINT [PK_Skill] PRIMARY KEY ([Id])
);

CREATE TABLE [Metas] (
  [LatestVersion] text NOT NULL
, CONSTRAINT [sqlite_autoindex_Metas_1] PRIMARY KEY ([LatestVersion])
);

