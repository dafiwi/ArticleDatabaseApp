using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ArticleDatabaseApp
{
    public partial class MainWindow : Window
    {
        public List<Article> DatabaseArticles { get; private set; }
        private double minimumPrice = 0.00;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Create()
        {
            using (DataContext dataContext = new DataContext())
            {
                try
                {
                    string articleName = ArticleTextBox.Text;
                    string color = ColorTextBox.Text;
                    string category = CategoryTextBox.Text;
                    double price = Convert.ToDouble(PriceTextBox.Text);

                    if (articleName != null && color != null && category != null && price > minimumPrice)
                    {
                        dataContext.Articles.Add(new Article() { ArticleName = articleName, Color = color, Category = category, Price = price });
                        dataContext.SaveChanges();
                    }

                    Read();
                }

                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }            
        }

        public void Read()
        {
            using (DataContext dataContext = new DataContext())
            {
                DatabaseArticles = dataContext.Articles.ToList();
                ArticleList.ItemsSource = DatabaseArticles;
            }
        }

        public void Update()
        {
            using (DataContext dataContext = new DataContext())
            {
                try
                {
                    Article selectedArticle = ArticleList.SelectedItem as Article;

                    string articleName = ArticleTextBox.Text;
                    string color = ColorTextBox.Text;
                    string category = CategoryTextBox.Text;
                    double price = Convert.ToDouble(PriceTextBox.Text);

                    if (articleName != null && color != null && category != null && price > minimumPrice)
                    {
                        Article article = dataContext.Articles.Find(selectedArticle.Id);

                        article.ArticleName = articleName;
                        article.Color = color;
                        article.Category = category;
                        article.Price = price;

                        dataContext.SaveChanges();
                    }

                    Read();
                }

                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        public void Delete()
        {
            using (DataContext dataContext = new DataContext())
            {
                try
                {
                    Article selectedArticle = ArticleList.SelectedItem as Article;

                    if (selectedArticle != null)
                    {
                        Article article = dataContext.Articles.Single(x => x.Id == selectedArticle.Id);

                        dataContext.Remove(article);
                        dataContext.SaveChanges();
                    }

                    Read();
                }

                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Create();
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            Read();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Delete();
        }

        private void ClearTextBoxesButton_Click(object sender, RoutedEventArgs e)
        {
            ArticleTextBox.Clear();
            ColorTextBox.Clear();
            CategoryTextBox.Clear();
            PriceTextBox.Clear();
        }
    }
}
