xlua.hotfix(CS.CompleteProject.EnemyManager,'Spawn',function(self)

local spawnIdx= CS.UnityEngine.Random.Range (0, 3)
spawnIdx=math.floor(spawnIdx)

 CS.UnityEngine.GameObject.Instantiate (self.enemy, self.spawnPoints[spawnPointIndex].position, self.spawnPoints[spawnPointIndex].rotation);
end
)