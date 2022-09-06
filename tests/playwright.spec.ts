import { test, expect } from '@playwright/test';

test('basic test', async ({ page }) => {
  await page.goto('/');
  await page.waitForSelector('h1');
  await expect(page.locator('a.navbar-brand')).toContainText('Kevin Trickey');
})