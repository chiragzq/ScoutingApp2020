import requests
import urllib.request, json
def get_event_qual_teams(event_code):
  all_matches = []
  user_agent = {'User-agent': "Mozilla/5.0"}
  key = '?X-TBA-Auth-Key=nkRpKyrwQU3P6XtznbFVHyq57mGz3N6e4kYUCwjigdBR6C50VYZ8FoKngBIySCiU'
  HEADER = {'X-TBA-Auth-Key': '0x3LtcI75fiT6AaueA5JuaT9QPKhDDtIjd7gGhNwwbi2dFtIz5L5rygjSbpAFKEZ'}
  r = requests.get("https://www.thebluealliance.com/api/v3/event/" + event_code + "/matches" + key, headers=HEADER)
  matches = json.loads(r.text)
  for match in matches:
    match_key = match['key']
    if match_key.split('_')[1][:2] == 'qm':
      team_keys = []
      print("new int[]{")
      for team in match['alliances']['blue']['team_keys']:
        team_keys.append(team[3:])
      for team in match['alliances']['red']['team_keys']:
        team_keys.append(team[3:])
      print(",".join(team_keys))
      all_matches.append(team_keys)
      print("},")
  return all_matches
print("{")
qual_matches = get_event_qual_teams('2020cafr')
print("}")
# print(qual_matches)
