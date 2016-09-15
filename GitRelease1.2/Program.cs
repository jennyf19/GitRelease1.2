using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;
using Octokit.Helpers;
using Octokit.Internal;
using System.Net;
using System.Net.Http;

namespace GitRelease1._2
{
   
    class Program
    {
        static void Main(string[] args)
        {
            myAsyncMethod();
            Console.ReadLine();
        }
        public static async void myAsyncMethod()
        {
            var owner = "Jennyf19";
            var repoName = "BinaryTree";
            var client = new GitHubClient(new ProductHeaderValue("JennysAwesomeGitRelease"), new Uri("https://github.com/"));
            client.Credentials = new Credentials("19d9306f0bff81971282e69b4fde3f9f7f8dc84f");
            var repository = client.Repository.Get(owner, repoName);

            Repository result = await client.Repository.Get("jennyf19", "BinaryTree");
            Console.WriteLine(result.Id);
            Console.WriteLine(result.Url);
            Console.WriteLine(result.Name);

            #region Add code here to create a new tag...
            //# Working with the Git Database

            //### Tag a Commit

            //            Tags can be created through the GitHub API

            //```
            //var tag = new NewTag
            //{
            //    Message = "Tagging a new release of Octokit",
            //    Tag = "v1.0.0",
            //    Object = "ee062e0", // short SHA
            //    Type = TaggedType.Commit, // TODO: what are the defaults when nothing specified?
            //    Tagger = new Signature
            //    {
            //        Name = "Brendan Forster",
            //        Email = "brendan@github.com",
            //        Date = DateTime.UtcNow
            //    }
            //};
            //            var result = await client.GitDatabase.Tags.Create("octokit", "octokit.net", tag);
            //            Console.WriteLine("Created a tag for {0} at {1}", result.Tag, result.Sha);
            //```

            //Or you can fetch an existing tag from the API:

            //var tag = await client.GitDatabase.Tags.Get("octokit", "octokit.net", "v1.0.0");
            #endregion

            // var tag = await client.Git.Tag.Get("jennyf19", "binaryTree", "v1.0.0");

            //var result2 = await client.GitDatabase.Tags.Get("jennyf19", "binaryTree", "v1.0.0");
            //var tagsResult = await client.Repository.GetAllTags(result.Id);
            //var tagFinal = tagsResult.First();

            var tag = await client.Git.Tag.Get("jennyf19", "binaryTree", "v1.0.0");

            if (tag == null) Console.WriteLine("null again!");
            else
            {try
                {
                    tag = await client.Git.Tag.Get("jennyf19", "binaryTree", "v1.0.0");
                }
                catch
                {
                    throw new NotFoundException("error", HttpStatusCode.NotFound);
                }

                {
                    Console.WriteLine("Not found exception again");
                }
                if (tag == null) Console.WriteLine("Null!");
                else
                {
                    NewRelease data = new NewRelease(tag.Tag);
                    try
                    {
                        Release releaseResult = await client.Repository.Release.Create("jennyf19", "BinaryTree", data);
                    }
                    catch (Octokit.NotFoundException e)
                    {
                        Console.WriteLine("Not found exception");
                    }
                }

                Console.WriteLine("All done.");

                #region Getting Started Code Sample
                /*public static async void myAsyncMethod()
                {
                    //var client = new GitHubClient(new ProductHeaderValue("JennysAwesomeGitRelease"));

                    var ghe = new Uri("https://github.com/jennyf19/");
                    var client = new GitHubClient(new ProductHeaderValue("JennysAwesomeGitRelease"), ghe);

                    var tokenAuth = new Credentials("19d9306f0bff81971282e69b4fde3f9f7f8dc84f");
                    client.Credentials = tokenAuth;
                    Console.Write(tokenAuth);

                    var user = await client.User.Current();

                    Repository result = await client.Repository.Get("jennyf19", "BinaryTree");
                    Console.WriteLine(result.Id);

                    #region Add code here to create a new tag...
                    //# Working with the Git Database

                    //### Tag a Commit

                    //            Tags can be created through the GitHub API

                    //```
                    //var tag = new NewTag
                    //{
                    //    Message = "Tagging a new release of Octokit",
                    //    Tag = "v1.0.0",
                    //    Object = "ee062e0", // short SHA
                    //    Type = TaggedType.Commit, // TODO: what are the defaults when nothing specified?
                    //    Tagger = new Signature
                    //    {
                    //        Name = "Brendan Forster",
                    //        Email = "brendan@github.com",
                    //        Date = DateTime.UtcNow
                    //    }
                    //};
                    //            var result = await client.GitDatabase.Tags.Create("octokit", "octokit.net", tag);
                    //            Console.WriteLine("Created a tag for {0} at {1}", result.Tag, result.Sha);
                    //```

                    //Or you can fetch an existing tag from the API:

                    //var tag = await client.GitDatabase.Tags.Get("octokit", "octokit.net", "v1.0.0");
                    #endregion

                    //var tag = await client.GitDatabase.Tags.Get("jennyf19", "binaryTree", "v1.0.0");
                    var tagsResult = await client.Repository.GetAllTags(result.Id);
                    var tag = tagsResult.FirstOrDefault();

                    if (tag == null) Console.WriteLine("null!");
                    else
                    {
                        NewRelease data = new NewRelease(tag.Name);
                        try
                        {
                            Release releaseResult = await client.Repository.Release.Create("jennyf19", "BinaryTree", data);
                        }
                        catch (Octokit.NotFoundException e)
                        {
                            Console.WriteLine("Not found exception");
                        }
                    }

                    Console.WriteLine("All done.");
                }*/
                #endregion
            }

        }
    }
}


