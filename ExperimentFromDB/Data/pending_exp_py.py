import requests
import datetime
import json
import os
import sys
import time

index_url = 'http://hk-qaweb-2b01:9200/qa_test_exp_running_by_team'
index_url_v2 = 'http://hk-qaweb-2b01:9200/qa_test_exp_running_by_team_v2'

def es_request(method):
    r = requests.request(method, index_url)
    if r.status_code == 200:
        return True
    else:
        return False

def create_index():
    return es_request('PUT') 

def delete_index():
    return es_request('DELETE') 


delete_request = delete_index()
delete_attemps = 0

while delete_attemps < 3:
    if delete_request:
        print 'delete index'
        break
    else:
        delete_request = delete_index()
        delete_attemps += 1
        print 'delete_attemps', delete_attemps 
    
if not delete_request:
    print 'cannot delete index'
    sys.exit(2)
else:

    create_attemps = 0
    isIndexCreated = create_index()

    while create_attemps < 3:
        if isIndexCreated:
            print 'index created'
            break
        else:
            isIndexCreated = create_index()
            create_attemps += 1
            print 'create_attemps', create_attemps

    if not isIndexCreated:
        print 'cannot create index'
        sys.exit(2)

time.sleep(5)

pending_exps = 'pending_exp.json'

if not os.path.exists(pending_exps):
    print 'invalid input for process'
    sys.exit(0)

explist = json.load(open('pending_exp.json'))

rec_created = datetime.datetime.utcnow().strftime('%Y-%m-%dT%H:%M:%S.000Z')

print len(explist)

for running_exp in explist:
    url = "http://hk-qaweb-2b01:9200/qa_test_exp_running_by_team/detail/%s" % running_exp['ExperimentName']
    url_v2 = "%s/detail/%s%d" % (index_url_v2, running_exp['ExperimentName'], time.time() * 1000)

    payload = running_exp
    payload["when"] = rec_created
    print payload
    r = requests.post(url, json=payload)
    print r.text
    r2 = requests.post(url_v2, json=payload)
