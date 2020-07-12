# ConnectingS3
Connect local to AWS S3 Bucket and Move file from local and store it into S3 Bucket

Commands -
aws s3 ls
aws s3 ls bdp-lambdas-dev/stats/
aws s3 cp C:\Users\admin\Desktop\Test\TeamsSeason.docx  s3://bdp-lambdas-dev/stats/      copy from local to s3
aws s3 cp  C:\ConnectingAWS\S3\ s3://bdp-lambdas-dev/stats/ --recursive					 copy bulk files from local to s3
aws s3 rm s3://bdp-lambdas-dev/stats/TeamsSeason.docx                                    delete
