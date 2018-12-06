
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

ps=self:GetComponent(typeof(CS.PlayerShooting))

ps.enabled=true
self.enabled=false

end
)



xlua.hotfix(CS.GameManager,'InitEnemyPool',function(self)

 self:AddEnemy("game/enemy.eae", "ZomBunny")
 self:AddEnemy("game/enemy.eae", "ZomBear")
 self:AddEnemy("game/enemy.eae", "CHellephant")
 
end
)


xlua.hotfix(CS.GameManager,'Update',function(self)

     self.tick = self.tick + 1
	 if (self.tick % 200) == 0 then
          self:RandomBullet()
    end
 
end
)