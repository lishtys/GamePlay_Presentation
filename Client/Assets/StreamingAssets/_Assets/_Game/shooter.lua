
xlua.private_accessible(CS.CompleteProject.EnemyManager)
xlua.hotfix(CS.CompleteProject.EnemyManager,'Spawn',function(self)

if self.playerHealth.currentHealth>50 then self.spawnTime = 1
end

mytable = {self.spawnPoints}
print(#mytable)
local spawnIdx= CS.UnityEngine.Random.Range (0, #mytable)
spawnIdx=math.floor(spawnIdx)

CS.UnityEngine.GameObject.Instantiate (self.enemy, self.spawnPoints[spawnIdx].position, self.spawnPoints[spawnIdx].rotation);
end
)


xlua.hotfix(CS.CompleteProject.PlayerShooting,'Start',function(self)
self.damagePerShot=100
self.timeBetweenBullets=0.1
self.range=150
end
)